using System.Collections.Generic;
using _common.Protocol;

namespace NodeProxy
{
    public interface INodeProxyListener
    {
        void OnWorkersCountRetreived(int count);
        void OnWorkerManagerError(string error);
        void OnRedisIpRetrived(string ip);
        void OnWorkersLoadRetreived(float load);
        void OnWorkersMemoryRetreived(float memory);

        void OnLibraryListRetreived(List<string> libraryList);
        void OnHasLibrary(string libraryName, bool hasLibrary);
        void OnLibraryInstalled(string libraryName);
        void OnLibraryManagerError(string msg);

        void OnWorkersMaxLimitRetreived(int limit);
        void OnWorkersCurrentLimitRetreived(int limit);
        void OnLoadStatusRetreived(LoadStatus status);
        void OnLoadStatusChanged(LoadStatus status);

        void OnTotalMemoryRetreived(float memory);
        void OnTotalLoadRetreived(float load);

        void OnConnectionError();
        void OnDisconnected();
        void OnConnected();
        void OnConnecting();
    }
}
