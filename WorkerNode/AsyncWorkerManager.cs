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
            _workerManager.WorkersCountChange += OnWorkersCountChange;
            _workerManager.WorkersLoadUpdated += OnWorkersLoadUpdated;
            _listeners = new List<IWorkerManagerListener>();
        }

        public void GetWorkersCount()
        {
            var count = _workerManager.GetWorkersCount();

            foreach (var workerManagerListener in _listeners)
            {
                workerManagerListener.OnWorkersCountRetreived(count);
            }
        }

        public void AddWorkers(int n)
        {
            _workerManager.AddWorkers(n);
        }

        public void RemoveWorkers(int n)
        {
            _workerManager.RemoveWorkers(n);
        }

        public void AddAllWorkers()
        {
            _workerManager.AddAllWorkers();
        }

        public void RemoveAllWorkers()
        {
            _workerManager.RemoveAllWorkers();
        }

        public void GetWorkersMemory()
        {
            var memory = _workerManager.GetUsedMemory();

            foreach (var workerManagerListener in _listeners)
            {
                workerManagerListener.OnWorkersMemoryRetreived(memory);
            }
        }

        public void GetWorkersLoad()
        {
            var load = _workerManager.GetTotalLoad();

            foreach (var workerManagerListener in _listeners)
            {
                workerManagerListener.OnWorkersLoadRetreived(load);
            }
        }

        private void OnWorkersCountChange(int count)
        {
            foreach (var workerManagerListener in _listeners)
            {
                workerManagerListener.OnWorkersCountRetreived(count);
            }
        }

        private void OnWorkersLoadUpdated(Tuple<float, float> load)
        {
            foreach (var workerManagerListener in _listeners)
            {
                workerManagerListener.OnWorkersLoadRetreived(load.Item1);
            }

            foreach (var workerManagerListener in _listeners)
            {
                workerManagerListener.OnWorkersMemoryRetreived(load.Item2);
            }
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
