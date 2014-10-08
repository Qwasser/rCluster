using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using _common.Protocol.Request;
using _common.Protocol.Response;

namespace _commonConsoleTests
{
    class Program
    {
        private static void Main(string[] args)
        {
            _common.SocketConnection.WorkerNodeSocket.StartListening(6273, null);

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(ip, 6273);
            TcpClient client = new TcpClient();
            client.Connect(endPoint);

            
            NetworkStream stream = client.GetStream();
            StreamWriter sw = new StreamWriter(stream);
            Thread.Sleep(500);
            _common.SocketConnection.WorkerNodeSocket.SendResponse(new CurrentWorkerLimitRetreivedResponse(234));
            StreamReader sr = new StreamReader(client.GetStream());
            Console.Out.WriteLine("here");
            Console.Out.WriteLine(sr.ReadLine());

            Console.ReadKey();
            sw.Close();
            _common.SocketConnection.WorkerNodeSocket.SendResponse(new CurrentWorkerLimitRetreivedResponse(234));
        }
    }
}
