using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Request
{
    class GetWorkersLoadRequest: AbstractRequestClusterMessage
    {
        public override void Handle(WorkerNodeContext context)
        {
            context.WorkerManager.GetWorkersLoad();
        }
    }
}
