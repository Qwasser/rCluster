using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Request
{
    public class SetLoadStatusRequest: AbstractRequestClusterMessage
    {
        private readonly LoadStatus _status;

        public SetLoadStatusRequest(LoadStatus status)
        {
            _status = status;
        }

        public override void Handle(WorkerNodeContext context)
        {
            context.LoadManager.SetStatus(_status);
        }
    }
}
