using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Request
{
    class StopWorkersRequest: AbstractRequestClusterMessage
    {
        private readonly int _workersToStop;

        public StopWorkersRequest(int workersToStop)
        {
            _workersToStop = workersToStop;
        }

        public override void Handle(WorkerNodeContext context)
        {
            context.WorkerManager.RemoveWorkers(_workersToStop);
        }
    }
}
