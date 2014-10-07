using System;

namespace WorkerNode
{
    public class WorkerThreadFactory : IWorkerThreadFactory
    {
        private const string ArgumentTemplate = " --slave -e \"require(doRedis);redisWorker(host = '{0}', port = {1}, queue='{2}')\" ";
        private const string RPath = @"C:\Program Files\R\R-3.1.1\bin\x64\Rscript";

        public WorkerThread CreateWorker(string redisIp, string redisPort, string queue, int id)
        {
            var script = String.Format(ArgumentTemplate, redisIp, redisPort, queue);

            return new WorkerThread(script, RPath, id);
        }
    }
}
