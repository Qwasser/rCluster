using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Response
{
    public class WorkerLoadRetreivedResponse: AbstractResponseClusterMessage
    {
        private readonly long _load;

        public WorkerLoadRetreivedResponse(long load)
        {
            this._load = load;
        }

        public override void Handle(MasterNodeContext context)
        {
            context.WorkerManagerListener.OnWorkersLoadRetreived(_load);
        }
    }
}
