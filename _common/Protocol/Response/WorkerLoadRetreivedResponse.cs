using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Response
{
    [Serializable]
    public class WorkerLoadRetreivedResponse: AbstractResponseClusterMessage
    {
        private readonly float _load;

        public WorkerLoadRetreivedResponse(float load)
        {
            _load = load;
        }

        public override void Handle(MasterNodeContext context)
        {
            context.WorkerManagerListener.OnWorkersLoadRetreived(_load);
        }
    }
}
