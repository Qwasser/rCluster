using _common.Protocol.Request;

namespace _common_tests.ProtocolTest.RequestTest
{
    using NUnit.Framework;
    [TestFixture]
    class RequestTest
    {
        [Test]
        public void SystemInfoTest()
        {
            var testSystemReceiver = new TestSystemInfo();
            var context = new TestContext(new TestLibraryManager(), new TestLoadManager(), testSystemReceiver,
                new TestWorkerManager());
            var sender = new RemoteSystemInfo(context);

            sender.GetSystemLoad();
            Assert.AreEqual(TestSystemInfo.SystemLoadResult, testSystemReceiver.GetResult());

            sender.GetSystemMemory();
            Assert.AreEqual(TestSystemInfo.SystemMemoryResult, testSystemReceiver.GetResult());
        }
    }
}
