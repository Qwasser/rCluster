﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Response
{
    [Serializable]
    public class WorkerCountRetreivedResponse: AbstractResponseClusterMessage
    {
        private readonly int _count;

        public WorkerCountRetreivedResponse(int count)
        {
            _count = count;
        }

        public override void Handle(MasterNodeContext context)
        {
            context.WorkerManagerListener.OnWorkersCountRetreived(_count);
        }
    }
}
