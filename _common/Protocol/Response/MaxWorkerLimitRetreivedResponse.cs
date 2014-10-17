using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Response
{
    [Serializable]
    public class MaxWorkerLimitRetreivedResponse : AbstractResponseClusterMessage
    {
        private readonly int _limit;

        public MaxWorkerLimitRetreivedResponse(int limit)
        {
            _limit = limit;
        }

        public override void Handle(MasterNodeContext context)
        {
            context.LoadManagerListener.OnWorkersMaxLimitRetreived(_limit);
        }
    }
}
