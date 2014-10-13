using System;

namespace _common.Protocol.Request
{
    [Serializable]
    public class WorkersCountRequest: AbstractRequestClusterMessage
    {
        public override void Handle(WorkerNodeContext context)
        {
            context.WorkerManager.GetWorkersCount();
        }
    }
}
