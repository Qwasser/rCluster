using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using _common.Protocol.Request;

namespace _common_tests.ConnectionTest
{
    using NUnit.Framework;
    using _common.Protocol;
    using _common.SocketConnection;
    
    [TestFixture]
    class DataTransmittionTests
    {
        [Test]
        public void MessageFromServerTest()
        {
            // Set up environment
            var observer = new TestNodeConnectionObserver();
            var client = new MasterNodeSocket(new StringResponseHandler());
            client.AddObserver(observer);

            var requestHandler = new StringRequestHandler();
            // Run server on localhost
            WorkerNodeSocket.StartListening(6273, requestHandler);
            try
            {
                // Client is disconnected when created
                Assert.IsFalse(client.IsConnected());
                // COnnect to a server
                client.Connect("127.0.0.1", 6273);

                // Whait a bit for connection
                Thread.Sleep(200);
                // Check connected status
                Assert.AreEqual(observer.State, ConnectionUtils.ConnectionState.Connected);

                client.SendRequest(new GetCurrentWorkerLimitRequest());
                Thread.Sleep(200);

                Console.Out.WriteLine(requestHandler.Result);
            }
            catch (Exception)
            {
                {
                }
                throw;
            }
            finally
            {
                //Disconnect an check status
                client.Disconnect();
                Thread.Sleep(100);
                Assert.AreEqual(observer.State, ConnectionUtils.ConnectionState.Disconnected);

                WorkerNodeSocket.StopListening();
            }   
        }
    }
}
