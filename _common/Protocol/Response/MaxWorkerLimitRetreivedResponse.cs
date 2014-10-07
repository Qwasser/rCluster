﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Response
{
    public class MaxWorkerLimitRetreivedResponse : AbstractResponseClusterMessage
    {
        private readonly int _limit;

        public MaxWorkerLimitRetreivedResponse(int limit)
        {
            _limit = limit;
        }

        public override void Handle(MasterNodeContext context)
        {
            context.LoadManagerListener.OnMaxLimitRetreived(_limit);
        }
    }
}