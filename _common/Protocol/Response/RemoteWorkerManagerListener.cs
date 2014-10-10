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

        public void OnCountRetreived(int count)
        {
            _sender.SendResponse(new WorkerCountRetreivedResponse(count));
        }

        public void OnError(string error)
        {
            _sender.SendResponse(new WorkerErrorResponse(error));
        }

        public void OnRedisIpRetrived(string ip)
        {
            _sender.SendResponse(new RedisIpRetreivedResponse(ip));
        }

        public void OnWorkersLoadRetreived(long load)
        {
            _sender.SendResponse(new WorkerLoadRetreivedResponse(load));
        }

        public void OnWorkersMemoryRetreived(long memory)
        {
            throw new NotImplementedException();
        }
    }
}
