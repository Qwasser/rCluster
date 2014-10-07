using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _common.NodeInterfaces;

namespace _common.Protocol.Request
{
    public class RemoteSystemInfo: IAsyncSystemInfo
    {
        private readonly IRequestSender _sender;
        public RemoteSystemInfo(IRequestSender sender)
        {
            _sender = sender;
        }
        public void GetSystemMemory()
        {
            _sender.SendRequest(new GetSystemMemoryRequest());
        }

        public void GetSystemLoad()
        {
            _sender.SendRequest(new GetSystemLoadRequest());
        }

        public void AddListener(ISystemInfoListener listener)
        {
            throw new NotImplementedException();
        }

        public void RemoveListener(ISystemInfoListener listener)
        {
            throw new NotImplementedException();
        }
    }
}
