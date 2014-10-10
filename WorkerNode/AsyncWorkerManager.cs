using System;
using System.Collections.Generic;
using _common.NodeInterfaces;

namespace WorkerNode
{
    public class AsyncWorkerManager : IAsyncWorkerManager
    {
        private readonly IWorkerManager _workerManager;
        private readonly List<IWorkerManagerListener> _listeners;

        public AsyncWorkerManager(IWorkerManager workerManager)
        {
            _workerManager = workerManager;
            _listeners = new List<IWorkerManagerListener>();
        }

        public void GetWorkersCount()
        {
            var count = _workerManager.GetWorkersCount();

            foreach (var workerManagerListener in _listeners)
            {
                workerManagerListener.OnCountRetreived(count);
            }
        }

        public void AddWorkers(int n)
        {
            _workerManager.AddWorkers(n);

            var count = _workerManager.GetWorkersCount();

            foreach (var workerManagerListener in _listeners)
            {
                workerManagerListener.OnCountRetreived(count);
            }
        }

        public void RemoveWorkers(int n)
        {
            _workerManager.RemoveWorkers(n);

            var count = _workerManager.GetWorkersCount();

            foreach (var workerManagerListener in _listeners)
            {
                workerManagerListener.OnCountRetreived(count);
            }
        }

        public void AddAllWorkers()
        {
            _workerManager.AddAllWorkers();

            var count = _workerManager.GetWorkersCount();

            foreach (var workerManagerListener in _listeners)
            {
                workerManagerListener.OnCountRetreived(count);
            }
        }

        public void RemoveAllWorkers()
        {
            _workerManager.RemoveAllWorkers();

            var count = _workerManager.GetWorkersCount();

            foreach (var workerManagerListener in _listeners)
            {
                workerManagerListener.OnCountRetreived(count);
            }
        }

        public void GetWorkersMemory()
        {
            throw new NotImplementedException();
        }

        public void GetWorkersLoad()
        {
            throw new NotImplementedException();
        }

        public void AddListener(IWorkerManagerListener listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(IWorkerManagerListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}
