using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Response
{
    public class CurrentWorkerLimitRetreivedResponse: AbstractResponseClusterMessage
    {
        private readonly int _limit;

        public CurrentWorkerLimitRetreivedResponse(int limit)
        {
            this._limit = limit;
        }

        public override void Handle(MasterNodeContext context)
        {
            context.LoadManagerListener.OnCurrentLimitRetreived(_limit);
        }
    }
}
