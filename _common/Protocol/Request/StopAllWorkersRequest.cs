using System;

namespace _common.Protocol.Request
{
    [Serializable]
    public class StopAllWorkersRequest: AbstractRequestClusterMessage
    {
        public override void Handle(WorkerNodeContext context)
        {
            context.WorkerManager.RemoveAllWorkers();
        }
    }
}
