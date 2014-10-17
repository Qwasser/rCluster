using _common.Protocol.Response;

namespace _common.SocketConnection
{
    public interface INodeConnection
    {
        bool IsConnected();
        void Connect(string ip, int port);
        void Disconnect();
        void SetResponseHandler(IResponseHandler response);
        void AddObserver(INodeConnectionObserver observer);

    }
}
