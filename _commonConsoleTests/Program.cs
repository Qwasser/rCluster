using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
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

            MasterNodeSocket client = new MasterNodeSocket(new ConsoleHandler());

            client.Connect("127.0.0.1", 6273);
            Console.ReadKey();



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
