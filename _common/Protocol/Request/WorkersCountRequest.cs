namespace _common.Protocol.Request
{
    public class WorkersCountRequest: AbstractRequestClusterMessage
    {
        public override void Handle(WorkerNodeContext context)
        {
            context.WorkerManager.GetWorkersCount();
        }
    }
}
