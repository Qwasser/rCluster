using _common.Protocol;

namespace _common.NodeInterfaces
{
    public interface ILoadManagerListener
    {
        void OnWorkersMaxLimitRetreived(int limit);
        void OnWorkersCurrentLimitRetreived(int limit);
        void OnLoadStatusRetreived(LoadStatus status);
        void OnLoadStatusChanged(LoadStatus status);
    }
}
