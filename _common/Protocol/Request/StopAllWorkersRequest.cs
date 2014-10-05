namespace _common.Protocol.Request
{
    class StopAllWorkersRequest: AbstractRequestClusterMessage
    {
        public override void Handle(WorkerNodeContext context)
        {
            context.WorkerManager.RemoveAllWorkers();
        }
    }
}
