using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            System.Threading.Thread.Sleep(5000);
        }
    }
}
