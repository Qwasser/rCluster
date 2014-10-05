namespace _common.Protocol.Request
{
    class WorkersCountRequest: AbstractRequestClusterMessage
    {
        public override void Handle(WorkerNodeContext context)
        {
            context.WorkerManager.GetWorkersCount();
        }
    }
}
