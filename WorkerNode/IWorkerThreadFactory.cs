namespace WorkerNode
{
    public interface IWorkerThreadFactory
    {
        WorkerThread CreateWorker(string redisIp, string redisPort, string queue, int id);
    }
}
