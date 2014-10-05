namespace _common.NodeInterfaces
{
    /// <summary>
    /// Async interface for worker managing
    /// </summary>
    interface IAsyncWorkerManager
    {
        void GetWorkersCount();
        void AddWorkers(int n);
        void RemoveWorkers(int n);
        void AddAllWorkers();
        void RemoveAllWorkers();
        void SetRedisIp(string ip);
        void GetWorkersMemory();
        void GetWorkersLoad();
    }
}
