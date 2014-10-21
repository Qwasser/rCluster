using System;

namespace _common.Protocol.Response
{
    [Serializable]
    public class WorkerMemoryRetreivedResponse: AbstractResponseClusterMessage
    {
        private readonly float _memory;

        public WorkerMemoryRetreivedResponse(float memory)
        {
            _memory = memory;
        }

        public override void Handle(MasterNodeContext context)
        {
            context.WorkerManagerListener.OnWorkersMemoryRetreived(_memory);
        }
    }
}
