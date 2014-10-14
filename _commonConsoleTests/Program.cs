using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using _common.Protocol;
using _common.Protocol.Request;
using _common.Protocol.Response;
using _common.SocketConnection;

namespace _commonConsoleTests
{
    class Program
    {
        private static void Main(string[] args)
        {
            //_common.SocketConnection.WorkerNodeSocket.StartListening(6273, null);

            var client = new MasterNodeSocket(new ConsoleHandler());

            client.Connect("192.168.0.113", 6700);
            Thread.Sleep(100);
            Console.Out.WriteLine(client.IsConnected());
            Console.ReadKey();
            client.SendRequest(new SetLoadStatusRequest(new LoadStatus() {Limit = 2, LoadType = LoadStatusType.Limited}));
            Console.ReadKey();
            client.SendRequest(new AddWorkersRequest(1));
            Console.ReadKey();
            client.Disconnect();
        }

        public class ConsoleHandler : IResponseHandler
        {
            public void HandleResponse(AbstractResponseClusterMessage msg)
            {
                Console.Out.WriteLine(msg.ToString());
            }
        }
    }
}
