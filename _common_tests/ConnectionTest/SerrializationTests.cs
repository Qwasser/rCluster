using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _common.Protocol.Request;

namespace _common_tests.ConnectionTest
{
    using NUnit.Framework;
    using _common.SocketConnection;
    using _common.Protocol;
    [TestFixture]
    class SerrializationTests
    {
        [Test]
        public void SerealizeDeserialize()
        {
            AbstractRequestClusterMessage msg = new AddAllWorkersRequest();
            String serrialized = ConnectionUtils.Encode(msg);
            var decodedMsg = ConnectionUtils.TryDecode<AbstractRequestClusterMessage>(serrialized);
            Assert.AreEqual(msg.ToString(), decodedMsg.ToString());
        }
    }
}
