using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _common.Protocol.Response
{
    [Serializable]
    public class SystemLoadRetrivedResponse: AbstractResponseClusterMessage
    {
        private readonly float _load;

        public SystemLoadRetrivedResponse(float load)
        {
            _load = load;
        }

        public override void Handle(MasterNodeContext context)
        {
            context.SystemInfoListener.OnLoadRetreived(_load);
        }
    }
}
