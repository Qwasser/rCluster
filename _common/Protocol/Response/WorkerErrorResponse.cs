using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Response
{
    public class WorkerErrorResponse: AbstractResponseClusterMessage
    {
        private readonly string _msg;

        public WorkerErrorResponse(string msg)
        {
            _msg = msg;
        }

        public override void Handle(MasterNodeContext context)
        {
            context.WorkerManagerListener.OnError(_msg);
        }
    }
}
