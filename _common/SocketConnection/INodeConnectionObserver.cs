using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.SocketConnection
{
    public interface INodeConnectionObserver
    {
        void OnConnectionError();
        void OnDisconnected();
        void OnConnected();
        void OnConnecting();
    }
}
