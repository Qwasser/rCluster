﻿namespace _common.Protocol.Request
{
    class AddWorkersRequest: AbstractRequestClusterMessage
    {
        private readonly int _workersToAdd;
        public AddWorkersRequest(int workersToAdd)
        {
            _workersToAdd = workersToAdd;
        }
        public override void Handle(WorkerNodeContext context)
        {
            context.WorkerManager.AddWorkers(_workersToAdd);
        }
    }
}
