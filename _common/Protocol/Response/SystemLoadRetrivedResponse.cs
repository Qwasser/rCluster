using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _common.Protocol.Response
{
    public class SystemLoadRetrivedResponse: AbstractResponseClusterMessage
    {
        private readonly long _load;

        public SystemLoadRetrivedResponse(long load)
        {
            _load = load;
        }

        public override void Handle(MasterNodeContext context)
        {
            context.SystemInfoListener.OnLoadRetreived(_load);
        }
    }
}
