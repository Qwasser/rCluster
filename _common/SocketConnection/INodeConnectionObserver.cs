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
