using System;

namespace _common.Protocol.Request
{
    [Serializable]
    public class GetWorkersMemoryRequest: AbstractRequestClusterMessage
    {
        public override void Handle(WorkerNodeContext context)
        {
            context.WorkerManager.GetWorkersMemory();
        }
    }
}
