using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Request
{
    class SetRedisIpRequest: AbstractRequestClusterMessage
    {
        private readonly string _ip;

        public SetRedisIpRequest(string ip)
        {
            _ip = ip;
        }

        public override void Handle(WorkerNodeContext context)
        {
            //context.WorkerManager.SetRedisIp(_ip);
        }
    }
}
