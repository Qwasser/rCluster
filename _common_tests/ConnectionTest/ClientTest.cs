using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using _common.Protocol.Request;
using _common.SocketConnection;

namespace _common_tests.ConnectionTest
{
    using NUnit.Framework;
    using _common.SocketConnection;
    using _common.Protocol;
    [TestFixture]
    class ClientTest
    {
        [Test]
        public void ConnectToNothingTest()
        {
            // Set up environment
            var observer = new TestNodeConnectionObserver();
            var client = new MasterNodeSocket(new StringResponseHandler());
            client.AddObserver(observer);

            // Client is disconnected when created
            Assert.IsFalse(client.IsConnected());

            // Connecting to actual ip to a random port
            client.Connect("127.0.0.1", 6262);
            client.SendRequest(new AddAllWorkersRequest());

            // Wait for connection
            Thread.Sleep(2000);
            
            // Connection must fail and client must be dusconnected
            Assert.IsFalse(client.IsConnected());
            Assert.AreEqual(observer.State, ConnectionUtils.ConnectionState.Disconnected);
            client.Disconnect();
        }

        [Test]
        public void ConnectionTimeOutTest()
        {
            // Set up environment
            var observer = new TestNodeConnectionObserver();
            var client = new MasterNodeSocket(new StringResponseHandler());
            client.AddObserver(observer);

            // Client is disconnected when created
            Assert.IsFalse(client.IsConnected());

            // Connecting to actual ip to a random port
            client.Connect("192.168.0.100", 6262);
            client.SendRequest(new AddAllWorkersRequest());

            // Wait for connection timeout
            Thread.Sleep(5000);

            // Connection must fail and client must be dusconnected
            Assert.IsFalse(client.IsConnected());
            Assert.AreEqual(observer.State, ConnectionUtils.ConnectionState.Disconnected);
            client.Disconnect();
        }

        [Test]
        public void SimpleConnectionTest()
        {
            // Set up environment
            var observer = new TestNodeConnectionObserver();
            var client = new MasterNodeSocket(new StringResponseHandler());
            client.AddObserver(observer);

            // Run server on localhost
            WorkerNodeSocket.StartListening(6273, null);
            // Client is disconnected when created
            Assert.IsFalse(client.IsConnected());
            // COnnect to a server
            client.Connect("127.0.0.1", 6273);
            
            // Whait a bit for connection
            Thread.Sleep(100);
            // Check connected status
            Assert.AreEqual(observer.State, ConnectionUtils.ConnectionState.Connected);

            //Disconnect an check status
            client.Disconnect();
            Thread.Sleep(100);
            Assert.AreEqual(observer.State, ConnectionUtils.ConnectionState.Connected);

        }
      
    }
}
