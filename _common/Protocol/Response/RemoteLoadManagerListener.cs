using System;
using _common.NodeInterfaces;

namespace _common.Protocol.Response
{
    [Serializable]
    public class RemoteLoadManagerListener : ILoadManagerListener
    {
        private readonly IResponseSender _sender;

        public RemoteLoadManagerListener(IResponseSender sender)
        {
            this._sender = sender;
        }

        public void OnWorkersMaxLimitRetreived(int limit)
        {
            _sender.SendResponse(new MaxWorkerLimitRetreivedResponse(limit));
        }

        public void OnWorkersCurrentLimitRetreived(int limit)
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
