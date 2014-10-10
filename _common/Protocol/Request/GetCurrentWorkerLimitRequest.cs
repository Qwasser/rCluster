using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Request
{
    [Serializable]
    public class GetCurrentWorkerLimitRequest: AbstractRequestClusterMessage
    {
        public override void Handle(WorkerNodeContext context)
        {
            context.LoadManager.GetCurrentLimit();
        }
    }
}
