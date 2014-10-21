using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Channels;
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
        
        // Shut down event to stop all the threads
        public ManualResetEvent ShutDownEvent = new ManualResetEvent(false);

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
                _writer.WriteLine(ConnectionUtils.Encode(msg));
                _writer.Flush();
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
                ShutDownEvent.Set();
                NotifyDisconnected();
                _client.Close();
                _receiver._thread.Join();
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

        private sealed class Receiver
        {
            internal Receiver(NetworkStream stream, MasterNodeSocket parent)
            {
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

                    var reader = new StreamReader(_stream);
                    while (!_parent.ShutDownEvent.WaitOne(0))
                    {
                        try
                        {
                            string res = reader.ReadLine();
                            if (res != null)
                            {
                                _parent._responseHandler.HandleResponse(
                                    ConnectionUtils.TryDecode<AbstractResponseClusterMessage>(res));

                            }
                            else
                            {
                                // Reached end of stream. Must stop thread and close connection
                                _parent.Disconnect();
                            }
                        }
                        catch (IOException ex)
                        {
                            reader.Close();
                        }
                        
                    }

                }
                catch (Exception ex)
                {
                    _parent.Disconnect();
                }
                finally
                {
                    _stream.Close();
                }
            }

            private NetworkStream _stream;
            public Thread _thread;
            private MasterNodeSocket _parent;
        }
    }
}
