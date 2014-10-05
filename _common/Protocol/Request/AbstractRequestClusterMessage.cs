using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Request
{
    public abstract class AbstractRequestClusterMessage
    {
        public abstract void Handle(WorkerNodeContext context);
    }
}
