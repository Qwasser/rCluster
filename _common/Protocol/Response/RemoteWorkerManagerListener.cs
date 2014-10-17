using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _common.NodeInterfaces;

namespace _common.Protocol.Response
{
    public class RemoteWorkerManagerListener: IWorkerManagerListener
    {
        private readonly IResponseSender _sender;

        public RemoteWorkerManagerListener(IResponseSender sender)
        {
            _sender = sender;
        }

        public void OnWorkersCountRetreived(int count)
        {
            _sender.SendResponse(new WorkerCountRetreivedResponse(count));
        }

        public void OnWorkerManagerError(string error)
        {
            _sender.SendResponse(new WorkerErrorResponse(error));
        }

        public void OnRedisIpRetrived(string ip)
        {
            _sender.SendResponse(new RedisIpRetreivedResponse(ip));
        }

        public void OnWorkersLoadRetreived(float load)
        {
            _sender.SendResponse(new WorkerLoadRetreivedResponse(load));
        }

        public void OnWorkersMemoryRetreived(float memory)
        {
            throw new NotImplementedException();
        }
    }
}
