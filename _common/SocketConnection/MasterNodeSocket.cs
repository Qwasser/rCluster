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
    class MasterNodeSocket : IRequestSender, INodeConnection
    {
        private List<INodeConnectionObserver> _observers = new List<INodeConnectionObserver>();
        private TcpClient _client;
        private IResponseHandler _responseHandler;
        private bool _isConnected = false;
        private bool _isConnecting = false;

        private Receiver _receiver;
        private StreamWriter _writer = StreamWriter.Null;
        public ManualResetEvent ShutDownEvent = new ManualResetEvent(false);

        public MasterNodeSocket(IResponseHandler responseHandler)
        {
            this._responseHandler = responseHandler;
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
            return _isConnected;
        }

        public void Connect(string ip, int port)
        {
            if (!_isConnected && !_isConnecting)
            {
                NotifyConnecting();
                _isConnecting = true;
                _client = new TcpClient();
                ShutDownEvent.Reset();
                var callBack = new AsyncCallback(OnConnected);
                try
                {
                    _client.BeginConnect(IPAddress.Parse(ip), port, callBack, _client);
                }
                catch (Exception)
                {
                    _isConnecting = false;
                    NotifyDisconnected();
                }
            }
        }

        public void Disconnect()
        {
            _isConnected = false;
            ShutDownEvent.Set();
            NotifyDisconnected();
            _client.Close();
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
            _isConnecting = false;
            _isConnected = true;
            var client = (TcpClient) result.AsyncState;
            NotifyConnected();
            _receiver = new Receiver(client.GetStream(), this);
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
                            // We could use the ReadTimeout property and let Read()
                            // block.  However, if no data is received prior to the
                            // timeout period expiring, an IOException occurs.
                            // While this can be handled, it leads to problems when
                            // debugging if we are wanting to break when exceptions
                            // are thrown (unless we explicitly ignore IOException,
                            // which I always forget to do).
                            if (!_stream.DataAvailable)
                            {
                                // Give up the remaining time slice.
                                Thread.Sleep(1);
                            }
                            else 
                            {
                                string res = reader.ReadLine();
                                while (res != null)
                                {
                                    _parent._responseHandler.HandleResponse(ConnectionUtils.TryDecode<AbstractResponseClusterMessage>(res));
                                    res = reader.ReadLine();
                                }
                                
                                _parent.ShutDownEvent.Set();
                            }
                        }
                        catch (IOException ex)
                        {
                            // Handle the exception...
                        }
                    }
                }
                catch (Exception ex)
                {
                    _parent._isConnected = false;
                    _parent.NotifyDisconnected();
                }
                finally
                {
                    _stream.Close();
                }
            }

            private NetworkStream _stream;
            private Thread _thread;
            private MasterNodeSocket _parent;
        }
    }
}
