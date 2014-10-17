namespace _common.NodeInterfaces
{
    public interface IWorkerManagerListener
    {
        void OnWorkersCountRetreived(int count);
        void OnWorkerManagerError(string error);
        void OnRedisIpRetrived(string ip);
        void OnWorkersLoadRetreived(float load);
        void OnWorkersMemoryRetreived(float memory);
    }
}
