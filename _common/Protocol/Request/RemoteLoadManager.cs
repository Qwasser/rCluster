﻿using System;
using _common.NodeInterfaces;

namespace _common.Protocol.Request
{
    [Serializable]
    public class RemoteLoadManager: IAsyncLoadManager
    {
        private readonly IRequestSender _sender;
        public RemoteLoadManager(IRequestSender sender)
        {
            _sender = sender;
        }

        public void GetCurrentLimit()
        {
            _sender.SendRequest(new GetCurrentWorkerLimitRequest());
        }

        public void GetMaxLimit()
        {
            _sender.SendRequest(new GetMaxWorkerLimitRequest());
        }

        public void GetStatus()
        {
            _sender.SendRequest(new GetLoadStatusRequest());
        }

        public void SetStatus(LoadStatus status)
        {
            _sender.SendRequest(new SetLoadStatusRequest(status));
        }

        public void AddListener(ILoadManagerListener listener)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveListener(ILoadManagerListener listener)
        {
            throw new System.NotImplementedException();
        }
    }
}
