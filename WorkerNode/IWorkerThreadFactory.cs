using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerNode
{
    interface IWorkerThreadFactory
    {
        WorkerThread CreateWorker(string redisIp, string redisPort, string queue);
    }
}
