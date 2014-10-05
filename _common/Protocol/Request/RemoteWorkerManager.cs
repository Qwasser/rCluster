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
        private IRequestSender _sender;

        public RemoteWorkerManager(IRequestSender sender)
        {
            this._sender = sender;
        }

        public void GetWorkersCount()
        {
            throw new NotImplementedException();
        }

        public void AddWorkers(int n)
        {
            _sender.SendRequest(new AddWorkersRequest(n));
        }

        public void RemoveWorkers(int n)
        {
            throw new NotImplementedException();
        }

        public void AddAllWorkers()
        {
            throw new NotImplementedException();
        }

        public void RemoveAllWorkers()
        {
            throw new NotImplementedException();
        }

        public void SetRedisIp(string ip)
        {
            throw new NotImplementedException();
        }
    }
}
