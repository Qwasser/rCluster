namespace _common.Protocol.Response
{
    class WorkerMemoryRetreivedResponse: AbstractResponseClusterMessage
    {
        private readonly long _memory;

        public WorkerMemoryRetreivedResponse(long memory)
        {
            _memory = memory;
        }

        public override void Handle(MasterNodeContext context)
        {
            context.WorkerManagerListener.OnWorkersMemoryRetreived(_memory);
        }
    }
}
