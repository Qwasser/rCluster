using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Response
{
    [Serializable]
    public class LoadStatusRetrivedResponse: AbstractResponseClusterMessage
    {
        private readonly LoadStatus _status;

        public LoadStatusRetrivedResponse(LoadStatus status)
        {
            _status = status;
        }

        public override void Handle(MasterNodeContext context)
        {
            context.LoadManagerListener.OnLoadStatusRetreived(_status);
        }
    }
}
