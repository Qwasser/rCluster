using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Response
{
    public class WorkerCountRetreivedResponse: AbstractResponseClusterMessage
    {
        private readonly int _count;

        public WorkerCountRetreivedResponse(int count)
        {
            _count = count;
        }

        public override void Handle(MasterNodeContext context)
        {
            context.WorkerManagerListener.OnCountRetreived(_count);
        }
    }
}
