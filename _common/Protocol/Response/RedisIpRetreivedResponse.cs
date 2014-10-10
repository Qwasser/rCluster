using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Response
{
    [Serializable]
    public class RedisIpRetreivedResponse: AbstractResponseClusterMessage
    {
        private readonly string _ip;

        public RedisIpRetreivedResponse(string ip)
        {
            _ip = ip;
        }

        public override void Handle(MasterNodeContext context)
        {
            context.WorkerManagerListener.OnRedisIpRetrived(_ip);
        }
    }
}
