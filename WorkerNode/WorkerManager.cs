using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkerNode
{
    public class WorkerManager : IWorkerManager
    {
        private const int WorkerLimitConst = 0;

        private readonly string _redisIp;
        private readonly string _redisPort;
        private readonly string _queue;

        private int _maxId;

        public int WorkersLimit { get; private set; }
        
        private readonly LinkedList<WorkerThread> _workers;
        private readonly IWorkerThreadFactory _workerThreadFactory;

        public WorkerManager(string redisIp = "127.0.0.1", string redisPort = "6379", string queue = "jobs", IWorkerThreadFactory workerThreadFactory = null)
        {
            _redisIp = redisIp;
            _redisPort = redisPort;
            _queue = queue;

            WorkersLimit = WorkerLimitConst;

            _maxId = 0;

            _workers = new LinkedList<WorkerThread>();
            _workerThreadFactory = workerThreadFactory ?? new WorkerThreadFactory();
        }

        public int GetWorkersCount()
        {
            return _workers.Count;
        }

        public void SetWorkersLimit(int limit)
        {
            if (limit > WorkersLimit)
            {
                WorkersLimit = limit;
            }
            else
            {
                int n = WorkersLimit - limit;
                RemoveWorkers(n);

                WorkersLimit = limit;
            }
        }
 
        public void AddWorkers(int n)
        {
            for (var i = 0; i < n && _workers.Count < WorkersLimit; i++)
            {
                var newWorker = _workerThreadFactory.CreateWorker(_redisIp, _redisPort, _queue, ++_maxId);
                
                newWorker.OnSuccess += WokerSuccess;
                newWorker.OnFailure += WokerFailure;
                newWorker.OnMessage += WorkerMessage;

                _workers.AddLast(newWorker);
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
            AddWorkers(WorkersLimit);
        }

        public void RemoveAllWorkers()
        {
            RemoveWorkers(_workers.Count);
        }

        public long GetUsedMemory()
        {
            return _workers.Select(w => w.Memory).Sum();
        }

        public float GetTotalLoad()
        {
            return _workers.Select(w => w.CpuLoad).Sum();
        }

        private void WokerSuccess(Tuple<int, string> tuple)
        {
            lock (_workers)
            {
                var thread = _workers.FirstOrDefault(workerThread => workerThread.Id == tuple.Item1);

                _workers.Remove(thread);
            }
        }

        private void WokerFailure(Tuple<int, string> tuple)
        {
            lock (_workers)
            {
                var thread = _workers.FirstOrDefault(workerThread => workerThread.Id == tuple.Item1);

                _workers.Remove(thread);

                AddWorkers(1);
            }
        }

        private void WorkerMessage(Tuple<int, string> tuple)
        {
            
        }
    }
}
