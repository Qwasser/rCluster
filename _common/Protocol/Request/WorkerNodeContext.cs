using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _common.NodeInterfaces;

namespace _common.Protocol.Request
{
    class WorkerNodeContext: IRequestHandler
    {
        public readonly IAsyncLibraryManager LibraryManager;
        public readonly IAsyncLoadManager LoadManager;
        public readonly IAsyncSystemInfo SystemInfo;
        public readonly IAsyncWorkerManager WorkerManager;
        public WorkerNodeContext(IAsyncLibraryManager libraryManager, IAsyncLoadManager loadManager, 
            IAsyncSystemInfo systemInfo, IAsyncWorkerManager workerManager)
        {
            LibraryManager = libraryManager;
            LoadManager = loadManager;
            SystemInfo = systemInfo;
            WorkerManager = workerManager;
        }

        public void HandleRequest(AbstractRequestClusterMessage msg)
        {
            msg.Handle(this);
        }
    }
}
