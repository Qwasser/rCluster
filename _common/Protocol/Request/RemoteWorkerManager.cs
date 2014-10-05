using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _common.NodeInterfaces;

namespace _common.Protocol.Request
{
    class RemoteWorkerManager: IAsyncWorkerManager
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
            throw new NotImplementedException();
        }

        public void SetRedisIp(string ip)
        {
            throw new NotImplementedException();
        }

        public void GetWorkersMemory()
        {
            throw new NotImplementedException();
        }

        public void GetWorkersLoad()
        {
            throw new NotImplementedException();
        }
    }
}
