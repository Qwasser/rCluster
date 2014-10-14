﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using _common.Protocol.Request;
using _common.Protocol.Response;

namespace _common.SocketConnection
{
    public class WorkerNodeSocket : IResponseSender
    {
        private static TcpListener _listener;
        private static IRequestHandler _requestHandler;
        private static TcpClient _connectedClient = null;
        private static StreamWriter _writer = StreamWriter.Null;
        public static void StartListening(int port, IRequestHandler requestHnadler)
        {
            _requestHandler = requestHnadler;
            
            // Getting local ips
            var ipHost = Dns.GetHostEntry(Dns.GetHostName());
            var ipAddr = IPAddress.Any;
            var ipEndPoint = new IPEndPoint(ipAddr, port);

            _listener = new TcpListener(ipEndPoint);
            _listener.Start(0);
            AsyncAcceptConnection();
        }

        public static void StopListening()
        {
            if (_connectedClient != null)
            {
                _connectedClient.Close();
            }
            _listener.Stop();
        }

        private static void AsyncAcceptConnection()
        {
            try
            {
                var clientTask = Task.Factory.FromAsync<TcpClient>(_listener.BeginAcceptTcpClient,
                    _listener.EndAcceptTcpClient, _listener);
                clientTask.ContinueWith(c => SaveConnection(c.Result)).ContinueWith(c => ContinuousReceive(c.Result));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
        }

        private static NetworkStream SaveConnection(TcpClient client)
        {
            _connectedClient = client;
            _writer = new StreamWriter(client.GetStream());
            return client.GetStream();
        }

        public static void SendResponse(AbstractResponseClusterMessage msg)
        {
            if (_writer != StreamWriter.Null)
            {
                
                _writer.WriteLine(ConnectionUtils.Encode(msg));
                _writer.Flush();
            }
        }

        private static void ContinuousReceive(NetworkStream stream)
        {
            try
            {
                var reader = new StreamReader(stream);
                bool shutdown = false;
                while (!shutdown)
                {
                    try
                    {
                        //Console.Out.WriteLine("here");
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
                        string str = ex.ToString();
                    }
                }         
                reader.Close();
                _writer.Close();
                _writer = StreamWriter.Null;
                _connectedClient.Close();

            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.ToString());
            }
            finally
            {
                
                _writer = StreamWriter.Null;
                stream.Close();
                _connectedClient.Close();
                AsyncAcceptConnection();
            } 
        }

        void IResponseSender.SendResponse(AbstractResponseClusterMessage response)
        {
            SendResponse(response);
        }
    }
}
