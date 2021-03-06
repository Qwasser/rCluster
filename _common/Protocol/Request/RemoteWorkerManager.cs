﻿using _common.NodeInterfaces;

namespace _common.Protocol.Request
{
    public class RemoteWorkerManager: IAsyncWorkerManager
    {
        private readonly IRequestSender _sender;

        public RemoteWorkerManager(IRequestSender sender)
        {
            this._sender = sender;
        }

        public void GetWorkersCount()
        {
            _sender.SendRequest(new WorkersCountRequest());
        }

        public void AddWorkers(int n)
        {
            _sender.SendRequest(new AddWorkersRequest(n));
        }

        public void RemoveWorkers(int n)
        {
            _sender.SendRequest(new StopWorkersRequest(n));
        }

        public void AddAllWorkers()
        {
            _sender.SendRequest(new AddAllWorkersRequest());
        }

        public void RemoveAllWorkers()
        {
            _sender.SendRequest(new StopAllWorkersRequest());
        }

        public void SetRedisIp(string ip)
        {
            _sender.SendRequest(new SetRedisIpRequest(ip));
        }

        public void GetWorkersMemory()
        {
            _sender.SendRequest(new GetWorkersMemoryRequest());
        }

        public void GetWorkersLoad()
        {
            _sender.SendRequest(new GetWorkersLoadRequest());
        }

        public void AddListener(IWorkerManagerListener listener)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveListener(IWorkerManagerListener listener)
        {
            throw new System.NotImplementedException();
        }
    }
}
