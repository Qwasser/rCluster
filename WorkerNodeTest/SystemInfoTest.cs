using System;
using System.Threading;
using WorkerNode;
using NUnit.Framework;

namespace WorkerNodeTest
{
    [TestFixture]
    class SystemInfoTest
    {
        [Ignore]
        [Test]
        public void Test()
        {
            var si = new SystemInfo();

            Thread.Sleep(2000);

            Console.WriteLine(si.GetMemory());
            Console.WriteLine(si.GetLoad());
        }
    }
}
