using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.SocketConnection
{
    public interface INodeConnection
    {
        bool IsConnected();
        void Connect(string ip, int port);
        void Disconnect();
        void AddObserver(INodeConnectionObserver observer);

    }
}
