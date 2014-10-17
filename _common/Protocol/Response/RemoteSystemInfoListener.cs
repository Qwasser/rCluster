using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _common.NodeInterfaces;

namespace _common.Protocol.Response
{
    public class RemoteSystemInfoListener: ISystemInfoListener
    {
        private readonly IResponseSender _sender;

        public RemoteSystemInfoListener(IResponseSender sender)
        {
            _sender = sender;
        }

        public void OnTotalMemoryRetreived(float memory)
        {
            _sender.SendResponse(new SystemMemoryRetrivedResponse(memory));
        }

        public void OnTotalLoadRetreived(float load)
        {
            _sender.SendResponse(new SystemLoadRetrivedResponse(load));
        }
    }
}
