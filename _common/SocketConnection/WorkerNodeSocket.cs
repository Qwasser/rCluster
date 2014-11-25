using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Threading;
using _common.Protocol.Request;
using _common.Protocol.Response;

namespace _common.SocketConnection
{
    public class WorkerNodeSocket : IResponseSender
    {
        private static TcpListener _listener;
        private static IRequestHandler _requestHandler;
        private static TcpClient _connectedClient;
        private static StreamWriter _writer = StreamWriter.Null;
        private static bool _connected = false;
        private static ConnectionHandler _connectionHandler;

        // lock object
        private static readonly object Lock = new object();

        public static void StartListening(int port, IRequestHandler requestHnadler)
        {
            _connected = false;
            _requestHandler = requestHnadler;
            
            // Getting local ips
            var ipHost = Dns.GetHostEntry(Dns.GetHostName());
            var ipAddr = IPAddress.Any;
            var ipEndPoint = new IPEndPoint(ipAddr, port);

            _listener = new TcpListener(ipEndPoint);
            _listener.Start(0);

            _connectionHandler = new ConnectionHandler();
        }

        public static void StopListening()
        {
            if (_connected)
            {
                _connectedClient.GetStream().Close();
                _connectedClient.Close();
            }
            _connectionHandler.Stop();
            _listener.Stop();
            _connectionHandler.Thread.Join();    
        }

        public static void SendResponse(AbstractResponseClusterMessage msg)
        {
            lock (Lock)
            {
                if (_connected)
                {
                    try
                    {
                        _writer.WriteLine(ConnectionUtils.Encode(msg));
                        _writer.Flush();
                    }
                    catch (IOException exception)
                    {
                        _writer.Close();
                        _writer = StreamWriter.Null;
                    }
                    catch (ObjectDisposedException e2)
                    {

                    }
                }
            }
        }

        private sealed class ConnectionHandler
        {
            private bool _isStopped = false;
            internal readonly Thread Thread;
            public void Stop()
            {
                _isStopped = true;
            }
            internal ConnectionHandler()
            {
                Thread = new Thread(Run);
                Thread.Start();
            }

            private void Run()
            {
                
                while (!_isStopped)
                {
                    
                    IAsyncResult result = _listener.BeginAcceptTcpClient(null, null);
                    // wait for connection
                    bool success = result.AsyncWaitHandle.WaitOne();

                    if (success && !_isStopped)
                    {
                        _connectedClient = _listener.EndAcceptTcpClient(result);
                        _connected = true;

                        var stream = _connectedClient.GetStream();
                        _writer = new StreamWriter(stream);
                        var reader = new StreamReader(stream);

                        try
                        {
                            
                            bool shutdown = false;
                            while (!shutdown)
                            {
                                try
                                {
                                    string res = reader.ReadLine();
                                    while (res != null)
                                    {
                                        _requestHandler.HandleRequest(
                                            ConnectionUtils.TryDecode<AbstractRequestClusterMessage>(res));

                                        res = reader.ReadLine();
                                    }
                                    shutdown = true;
                                }
                                catch (IOException ex)
                                {
                                    // input is broken, break for clean up                                
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
            
                        }
                        finally
                        {
                            lock (Lock)
                            {
                                _connected = false;
                                reader.Close();
                                _writer.Close();
                                _writer = StreamWriter.Null;
                                _connectedClient.Close();              
                            }
                        } 
                    }
                }
            }
        }

        void IResponseSender.SendResponse(AbstractResponseClusterMessage response)
        {
            SendResponse(response);
        }
    }
}
