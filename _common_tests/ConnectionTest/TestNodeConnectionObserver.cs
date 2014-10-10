using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _common.SocketConnection;

namespace _common_tests.ConnectionTest
{
    class TestNodeConnectionObserver: INodeConnectionObserver
    {
        public ConnectionUtils.ConnectionState State = ConnectionUtils.ConnectionState.Disconnected;
        public void OnConnectionError()
        {
            State = ConnectionUtils.ConnectionState.Disconnected;
        }

        public void OnDisconnected()
        {
            State = ConnectionUtils.ConnectionState.Disconnected;
        }

        public void OnConnected()
        {
            State = ConnectionUtils.ConnectionState.Connected;
        }

        public void OnConnecting()
        {
            State = ConnectionUtils.ConnectionState.Connecting;
        }
    }
}
