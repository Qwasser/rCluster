using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _common.NodeInterfaces;

namespace _common.Protocol.Response
{
    public class MasterNodeContext: IResponseHandler
    {
        public readonly ILibraryManagerListener LibraryManagerListener;
        public readonly IWorkerManagerListener WorkerManagerListener;
        public readonly ISystemInfoListener SystemInfoListener;
        public readonly ILoadManagerListener LoadManagerListener;
        public MasterNodeContext(ILibraryManagerListener libraryManagerListener, IWorkerManagerListener workerManagerListener, ISystemInfoListener systemInfoListener, ILoadManagerListener loadManagerListener)
        {
            LibraryManagerListener = libraryManagerListener;
            WorkerManagerListener = workerManagerListener;
            SystemInfoListener = systemInfoListener;
            LoadManagerListener = loadManagerListener;
        }

        public void HandleResponse(AbstractResponseClusterMessage msg)
        {
            if (!_stopHandling)
            {
                msg.Handle(this);
            }
        }

        public void StopHandling()
        {
            this._stopHandling = true;
        }

        private bool _stopHandling;
    }
}
