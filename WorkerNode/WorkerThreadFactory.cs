﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerNode
{
    class WorkerThreadFactory : IWorkerThreadFactory
    {
        private const string ArgumentTemplate = " --slave -e \"require(doRedis);redisWorker(host = '{0}', port = '{1}', queue='{2}', timeout=30)\" ";
        private const string RPath = @"C:\Program Files\R\R-3.1.1\bin\x64\Rscript";

        public WorkerThread CreateWorker(string redisIp, string redisPort, string queue)
        {
            var script = String.Format(ArgumentTemplate, redisIp, redisPort, queue);

            return new WorkerThread(script, RPath);
        }
    }
}