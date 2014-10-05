using _common.Protocol;
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

        [Test]
        public void LoadManagerTest()
        {
            var testLoadManager = new TestLoadManager();
            var context = new TestContext(new TestLibraryManager(), testLoadManager, new TestSystemInfo(), 
                new TestWorkerManager());
            var sender = new RemoteLoadManager(context);

            sender.GetCurrentLimit();
            Assert.AreEqual(TestLoadManager.CurrentLimitResult, testLoadManager.GetResult());

            sender.GetMaxLimit();
            Assert.AreEqual(TestLoadManager.MaxLimitResult, testLoadManager.GetResult());

            sender.GetStatus();
            Assert.AreEqual(TestLoadManager.GetStatusResult, testLoadManager.GetResult());

            var ls = new LoadStatus();
            sender.SetStatus(ls);
            Assert.AreEqual(ls.ToString(), testLoadManager.GetResult());

        }

        [Test]
        public void LibraryManagerTest()
        {
            var testLibraryManager = new TestLibraryManager();
            var context = new TestContext(testLibraryManager, new TestLoadManager(), new TestSystemInfo(),
                new TestWorkerManager());
            var sender = new RemoteLibraryManager(context);

            sender.GetLibraryList();
            Assert.AreEqual(TestLibraryManager.GetLibraryListResult, testLibraryManager.GetResult());

            const string libName = "myLib";
            sender.HasLibrary(libName);
            Assert.AreEqual(TestLibraryManager.HasLibraryResult + libName, testLibraryManager.GetResult());

            sender.InstallLibrary(libName);
            Assert.AreEqual(TestLibraryManager.InstallLibraryResult + libName, testLibraryManager.GetResult());
        }

        [Test]
        public void WorkerManagerTest()
        {
            var testWorkerManager = new TestWorkerManager();
            var context = new TestContext(new TestLibraryManager(), new TestLoadManager(), new TestSystemInfo(),
                testWorkerManager);
            var sender = new RemoteWorkerManager(context);

            const int count = 125;
            sender.AddWorkers(count);
            Assert.AreEqual(TestWorkerManager.AddWorkersResult + count, testWorkerManager.GetResult());

            sender.RemoveWorkers(count);
            Assert.AreEqual(TestWorkerManager.StopWorkersResult + count, testWorkerManager.GetResult());

            sender.RemoveAllWorkers();
            Assert.AreEqual(TestWorkerManager.StopAllWorkersResult, testWorkerManager.GetResult());

            sender.AddAllWorkers();
            Assert.AreEqual(TestWorkerManager.AddAllWorkersResult, testWorkerManager.GetResult());

            sender.GetWorkersCount();
            Assert.AreEqual(TestWorkerManager.GetWorkersCountResult, testWorkerManager.GetResult());
            
            sender.GetWorkersLoad();
            Assert.AreEqual(TestWorkerManager.GetWorkersLoadResult, testWorkerManager.GetResult());
            
            sender.GetWorkersMemory();
            Assert.AreEqual(TestWorkerManager.GetWorkersMemoryResult, testWorkerManager.GetResult());

            const string ip = "192.168.0.1";
            sender.SetRedisIp(ip);
            Assert.AreEqual(TestWorkerManager.SetRedisIpResult + ip, testWorkerManager.GetResult());
        }
    }
}
