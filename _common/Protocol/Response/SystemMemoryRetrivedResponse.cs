using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Response
{
    public class SystemMemoryRetrivedResponse: AbstractResponseClusterMessage
    {
        private readonly long _memory;

        public SystemMemoryRetrivedResponse(long memory)
        {
            _memory = memory;
        }

        public override void Handle(MasterNodeContext context)
        {
            context.SystemInfoListener.OnMemoryRetreived(_memory);
        }
    }
}
