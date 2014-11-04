using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WorkerNode
{
    public class WorkerManager : IWorkerManager
    {
        private const int TimerInterval = 1000;
        public static readonly Object Obj = new Object();
        private static Mutex mutex = new Mutex(false, "test");
        private const int WorkerLimitConst = 0;

        private readonly string _redisIp;
        private readonly string _redisPort;
        private readonly string _queue;

        private int _maxId;

        public int WorkersLimit { get; private set; }
        
        private readonly LinkedList<WorkerThread> _workers;
        private readonly IWorkerThreadFactory _workerThreadFactory;

        private readonly System.Timers.Timer _loadMonitorThread;

        public WorkerManager(string redisIp = "127.0.0.1", string redisPort = "6379", string queue = "jobs", IWorkerThreadFactory workerThreadFactory = null)
        {
            _redisIp = redisIp;
            _redisPort = redisPort;
            _queue = queue;

            WorkersLimit = WorkerLimitConst;

            _maxId = 0;

            _workers = new LinkedList<WorkerThread>();
            _workerThreadFactory = workerThreadFactory ?? new WorkerThreadFactory();

            _loadMonitorThread = new System.Timers.Timer()
            {
                Interval = TimerInterval,
                Enabled = true
            };

            _loadMonitorThread.Elapsed += (sender, args) =>
            {
                if (WorkersLoadUpdated != null)
                {
                    WorkersLoadUpdated(new Tuple<float, float>(GetTotalLoad(), GetUsedMemory()));
                }
            };

            _loadMonitorThread.Start();
        }

        public override int GetWorkersCount()
        {
            return _workers.Count;
        }

        public override void SetWorkersLimit(int limit)
        {
            if (limit < _workers.Count)
            {
                int n = _workers.Count - limit;
                RemoveWorkers(n);
            }

            WorkersLimit = limit;
        }
 
        public override void AddWorkers(int n)
        {
             try
            {
                mutex.WaitOne();
                for (var i = 0; i < n && _workers.Count < WorkersLimit; i++)
                {
                    var newWorker = _workerThreadFactory.CreateWorker(_redisIp, _redisPort, _queue, ++_maxId);

                    newWorker.OnSuccess += WokerSuccess;
                    newWorker.OnFailure += WokerFailure;
                    newWorker.OnMessage += WorkerMessage;

                    _workers.AddLast(newWorker);
                }
            }
             finally
             {
                 mutex.ReleaseMutex();
             }

            WorkersCountChange(_workers.Count);
        }

        public override void RemoveWorkers(int n)
        {
            try
            {
                mutex.WaitOne();
                for (int i = 0; i < n && _workers.Count > 0; i++)
                {
                    _workers.Last.Value.Dispose();
                    _workers.RemoveLast();
                }
                
            }
            finally
            {
                mutex.ReleaseMutex();
            }
            WorkersCountChange(_workers.Count);
        }

        public override void AddAllWorkers()
        {
            
            AddWorkers(WorkersLimit);
            
        }

        public override void RemoveAllWorkers()
        {
           
            RemoveWorkers(_workers.Count);
            
        }

        public override float GetUsedMemory()
        {
            float result = 0;
            
            try
            {
                mutex.WaitOne();
                result += _workers.Where(worker => !worker.HasExidet).Sum(worker => worker.Memory);
            }
            catch (InvalidOperationException e)
            {
                result = 0;
            }
            finally
            {
                mutex.ReleaseMutex();
            }
            return result;
        }

        public override float GetTotalLoad()
        {
            float result = 0;
            
            try
            {
                mutex.WaitOne();
                result += _workers.Where(worker => !worker.HasExidet).Sum(worker => (float) worker.CpuLoad);
            }
            catch (InvalidOperationException e)
            {
                result = 0;
            }
            finally
            {
                mutex.ReleaseMutex();
            }
            return result;
           
        }

        private void WokerSuccess(Tuple<int, string> tuple)
        {
            try
            {
                mutex.WaitOne();
                var thread = _workers.FirstOrDefault(workerThread => workerThread.Id == tuple.Item1);

                _workers.Remove(thread);

                WorkersCountChange(_workers.Count());
            }
            catch (InvalidOperationException e)
            {
                
            }
            finally
            {
                mutex.ReleaseMutex();
            }

            try
            {

                AddWorkers(1);
            }
            catch (InvalidOperationException e)
            {

            }
        }

        private void WokerFailure(Tuple<int, string> tuple)
        {
            try
            {
                mutex.WaitOne();
                var thread = _workers.FirstOrDefault(workerThread => workerThread.Id == tuple.Item1);


                _workers.Remove(thread);

                WorkersCountChange(_workers.Count());
            }
            finally
            {
                mutex.ReleaseMutex();
            }

        }

        private void WorkerMessage(Tuple<int, string> tuple)
        {
            
        }

        ~WorkerManager()
        {
            _loadMonitorThread.Stop();
        }
    }
}
