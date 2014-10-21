using System;

namespace _common.Protocol.Request
{
    [Serializable]
    public class GetWorkersLoadRequest: AbstractRequestClusterMessage
    {
        public override void Handle(WorkerNodeContext context)
        {
            context.WorkerManager.GetWorkersLoad();
        }
    }
}
