using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _common.NodeInterfaces;

namespace _common.Protocol.Response
{
    [Serializable]
    class RemoteLoadManagerListener : ILoadManagerListener
    {
        private readonly IResponseSender _sender;

        public RemoteLoadManagerListener(IResponseSender sender)
        {
            this._sender = sender;
        }

        public void OnMaxLimitRetreived(int limit)
        {
            _sender.SendResponse(new MaxWorkerLimitRetreivedResponse(limit));
        }

        public void OnCurrentLimitRetreived(int limit)
        {
            _sender.SendResponse(new CurrentWorkerLimitRetreivedResponse(limit));
        }

        public void OnLoadStatusRetreived(LoadStatus status)
        {
            _sender.SendResponse(new LoadStatusRetrivedResponse(status));
        }

        public void OnLoadStatusChanged(LoadStatus status)
        {
            _sender.SendResponse(new LoadStatusChangedResponse(status));
        }
    }
}
