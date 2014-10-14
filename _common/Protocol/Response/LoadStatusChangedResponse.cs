using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Response
{
    [Serializable]
    public class LoadStatusChangedResponse: AbstractResponseClusterMessage
    {
        private readonly LoadStatus _status;

        public LoadStatusChangedResponse(LoadStatus status)
        {
            _status = status;
        }

        public override void Handle(MasterNodeContext context)
        {
            context.LoadManagerListener.OnLoadStatusChanged(status: _status);
        }
    }
}
