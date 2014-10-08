using System;
using System.Threading;
using NUnit.Framework;
using WorkerNode;

namespace WorkerNodeTest
{
    [TestFixture]
    public class RThreadTest
    {
        [Ignore]
        [Test]
        public void WorkerManagerTest()
        {
            var wm = new WorkerManager();

            wm.AddAllWorkers();

            Console.WriteLine(wm.GetWorkersCount());

            Thread.Sleep(5000);
        }
    }
}
