using System;

namespace WorkerNode
{
    public class WorkerThreadFactory : IWorkerThreadFactory
    {
        private readonly string _argumentTemplate;
        private readonly string _rPath;

        public WorkerThreadFactory(string argumentTemplate = " --slave -e \"require(doRedis);redisWorker(host = '{0}', port = {1}, queue='{2}')\" ", 
            string rPath = @"C:\Program Files\R\R-3.1.1\bin\x64\Rscript")
        {
            _argumentTemplate = argumentTemplate;
            _rPath = rPath;
        }

        public WorkerThread CreateWorker(string redisIp, string redisPort, string queue, int id)
        {
            var script = String.Format(_argumentTemplate, redisIp, redisPort, queue);

            return new WorkerThread(script, _rPath, id);
        }
    }
}
