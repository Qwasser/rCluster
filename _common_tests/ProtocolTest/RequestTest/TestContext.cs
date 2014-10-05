using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _common.NodeInterfaces;
using _common.Protocol.Request;

namespace _common_tests.ProtocolTest.RequestTest
{
    class TestContext: WorkerNodeContext, IRequestSender
    {
        public TestContext(IAsyncLibraryManager libraryManager, IAsyncLoadManager loadManager, 
            IAsyncSystemInfo systemInfo, IAsyncWorkerManager workerManager) : base(libraryManager, loadManager, systemInfo, workerManager)
        {
        }

        public void SendRequest(AbstractRequestClusterMessage msg)
        {
            HandleRequest(msg);
        }
    }
}
