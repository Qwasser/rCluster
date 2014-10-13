namespace _common.NodeInterfaces
{
    /// <summary>
    /// Async interface for worker managing
    /// </summary>
    public interface IAsyncWorkerManager
    {
        void GetWorkersCount();
        void AddWorkers(int n);
        void RemoveWorkers(int n);
        void AddAllWorkers();
        void RemoveAllWorkers();
        void GetWorkersMemory();
        void GetWorkersLoad();

        void AddListener(IWorkerManagerListener listener);
        void RemoveListener(IWorkerManagerListener listener);
    }
}
