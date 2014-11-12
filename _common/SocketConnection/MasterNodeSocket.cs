using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using _common.Protocol.Request;
using System.Net.Sockets;
using _common.Protocol.Response;

namespace _common.SocketConnection
{
    public class MasterNodeSocket : IRequestSender, INodeConnection
    {
        private readonly List<INodeConnectionObserver> _observers = new List<INodeConnectionObserver>();
        
        // Current tcp client
        private TcpClient _client;
        private IResponseHandler _responseHandler;
        
        // State of connection
        private ConnectionUtils.ConnectionState _state = ConnectionUtils.ConnectionState.Disconnected;

        // Currently unning received thread
        private Receiver _receiver;
        // Current stream writer
        private StreamWriter _writer = StreamWriter.Null;
        private StreamReader _reader = StreamReader.Null;
        
        // Shut down event to stop all the threads
        public ManualResetEvent ShutDownEvent = new ManualResetEvent(false);
        
        // lock object
        private readonly object _lock = new object();

        public MasterNodeSocket(IResponseHandler responseHandler)
        {
            this._responseHandler = responseHandler;
        }

        public MasterNodeSocket()
        {
            
        }

        public void SendRequest(AbstractRequestClusterMessage msg)
        {
            if (IsConnected() && _writer != StreamWriter.Null)
            {
                lock (_lock)
                {
                    _writer.WriteLine(ConnectionUtils.Encode(msg));
                    _writer.Flush();
                }
            }
        }

        public bool IsConnected()
        {
            return _state == ConnectionUtils.ConnectionState.Connected;
        }

        public void Connect(string ip, int port)
        {
            if (_state == ConnectionUtils.ConnectionState.Disconnected)
            {
                // Changing state to connecting
                _state = ConnectionUtils.ConnectionState.Connecting;
                NotifyConnecting();

                // Create tcp client for connection
                _client = new TcpClient();

                // Reset the shutdown event
                ShutDownEvent.Reset();
                var callBack = new AsyncCallback(OnConnected);  
                IAsyncResult result = _client.BeginConnect(IPAddress.Parse(ip), port, callBack, _client);

                // Run task to close socket if connection is timed out
                Task.Factory.StartNew(() =>
                {
                    var wh = result.AsyncWaitHandle;
                    try
                    {
                        if (!result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(4), false))
                        {
                            // The logic to control when the connection timed out
                            _client.Close();
                            NotifyDisconnected();
                            _state = ConnectionUtils.ConnectionState.Disconnected;

                        }
                    }
                    finally
                    {
                        wh.Close();
                    }
                });
                
            }
        }

        public void Disconnect()
        {
            if (_state == ConnectionUtils.ConnectionState.Connected)
            {
                _state = ConnectionUtils.ConnectionState.Disconnected;
                
                _client.GetStream().Close();
                _client.Close();

                _receiver._stop_receive = true;
                
                var st = _receiver._thread.ThreadState;
                if (st == ThreadState.WaitSleepJoin)
                {
                   // _receiver._thread.Abort();
                }
                _receiver._thread.Join();
                NotifyDisconnected();
                
            }
        }

        public void SetResponseHandler(IResponseHandler response)
        {
            _responseHandler = response;
        }

        public void AddObserver(INodeConnectionObserver observer)
        {
            _observers.Add(observer);
        }

        private void NotifyConnected()
        {
            foreach (INodeConnectionObserver observer in _observers)
            {
                observer.OnConnected();
            }
        }

        private void NotifyDisconnected()
        {
            foreach (INodeConnectionObserver observer in _observers)
            {
                observer.OnDisconnected();
            }
        }

        private void NotifyConnecting()
        {
            foreach (INodeConnectionObserver observer in _observers)
            {
                observer.OnConnecting();
            }
        }

        private void OnConnected(IAsyncResult result)
        {
            if (_client.Client != null)
            {
                if (_client.Connected)
                {
                    // If client is succesfully connected - set the state and run receiver thread
                    _state = ConnectionUtils.ConnectionState.Connected;

                    _receiver = new Receiver(_client.GetStream(), this);
                    _writer = new StreamWriter(_client.GetStream());
                    NotifyConnected();

                }
                else
                {
                    // If not connected - close client, set disconnected status and notify observers
                    _client.Close();
                    _state = ConnectionUtils.ConnectionState.Disconnected;
                    NotifyDisconnected();
                }
            }
            else
            {
                _state = ConnectionUtils.ConnectionState.Disconnected;
                NotifyDisconnected();
            }
        }

        private sealed class Receiver
        {
            internal Receiver(NetworkStream stream, MasterNodeSocket parent)
            {
                _stop_receive = false;
                _stream = stream;
                _parent = parent;
                _thread = new Thread(Run);
                _thread.Start();
            }

            private void Run()
            {
                try
                {
                    // ShutdownEvent is a ManualResetEvent signaled by
                    // Client when its time to close the socket.
                    _stream.ReadTimeout = 4000;
                    _parent._reader = new StreamReader(_stream);

                    
                    while (!_stop_receive)
                    {
                        try
                        {
                            
                            string res = _parent._reader.ReadLine();
                            if (res != null && !_stop_receive)
                            {
                                _parent._responseHandler.HandleResponse(
                                    ConnectionUtils.TryDecode<AbstractResponseClusterMessage>(res));
                            }
                            else
                            {
                                // Reached end of stream. Must stop thread and close connection
                                break;
                            }
                        }
                        catch (IOException ex)
                        {
                            _parent._reader.Close();
                            break;
                        }
                        catch (SerializationException ex)
                        {
                            // wrong message - ignore
                        }
                    }

                }
                catch (SocketException ex)
                {
                    Console.Out.WriteLine(ex.ToString());
                }
                finally
                {
                    if (_parent._state != ConnectionUtils.ConnectionState.Disconnected)
                    {
                    
                        _stream.Close();
                        _parent._state = ConnectionUtils.ConnectionState.Disconnected;
                        _parent._reader.Close();
                        _parent._writer.Close();
                        _parent._client.Close();
                        _parent.NotifyDisconnected();
                    }
                }
            }
            public bool _stop_receive;
            private NetworkStream _stream;
            public Thread _thread;
            private MasterNodeSocket _parent;
        }
    }
}
