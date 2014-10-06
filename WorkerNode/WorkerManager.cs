using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerNode
{
    class WorkerManager : IWorkerManager
    {
        private const int WorkerLimitConst = 4;

        private readonly string _redisIp;
        private readonly string _redisPort;
        private readonly string _queue;

        public int WorkersCount
        {
            get { return _workers.Count; }
        }

        public int _workerLimit
        {
            get { return _workerLimit; }
            
            set
            {
                if (value > _workerLimit)
                {
                    _workerLimit = value;
                }
                else
                {
                    int n = _workerLimit - value;
                    RemoveWorkers(n);

                    _workerLimit = value;
                }
            }
        }

        private readonly LinkedList<WorkerThread> _workers;
        private readonly WorkerThreadFactory _workerThreadFactory;



        WorkerManager(string redisIp, string redisPort, string queue, WorkerThreadFactory workerThreadFactory = null)
        {
            _redisIp = redisIp;
            _redisPort = redisPort;
            _queue = queue;

            _workerLimit = WorkerLimitConst;

            _workers = new LinkedList<WorkerThread>();
            _workerThreadFactory = workerThreadFactory ?? new WorkerThreadFactory();
        }
 
        public void AddWorkers(int n)
        {
            for (int i = 0; i < n && _workers.Count < _workerLimit; i++)
            {
                _workers.AddLast(_workerThreadFactory.CreateWorker(_redisIp, _redisPort, _queue));
            }
        }

        public void RemoveWorkers(int n)
        {
            for (int i = 0; i < n && _workers.Count > 0; i++)
            {
                _workers.Last.Value.Dispose();
                _workers.RemoveLast();
            }
        }

        public void AddAllWorkers()
        {
            AddWorkers(_workerLimit);
        }

        public void RemoveAllWorkers()
        {
            foreach (var workerThread in _workers)
            {
                workerThread.Dispose();
            }

            _workers.Clear();
        }
    }
}
