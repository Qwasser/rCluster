using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Response
{
    [Serializable]
    public abstract class AbstractResponseClusterMessage
    {
        public abstract void Handle(MasterNodeContext context);
    }
}
