using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Request
{
    class WorkersCountRequest: AbstractRequestClusterMessage
    {
        public override void Handle(WorkerNodeContext context)
        {
            context.WorkerManager.GetWorkersCount();
        }
    }
}
