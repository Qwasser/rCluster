using System.Collections.Generic;
using _common.NodeInterfaces;
using _common.Protocol;

namespace WorkerNode
{
    class AsyncLoadManager : IAsyncLoadManager
    {

        private readonly ILoadManager _loadManager;
        private readonly List<ILoadManagerListener> _listeners; 

        public AsyncLoadManager(ILoadManager loadManager)
        {
            _loadManager = loadManager;
            _listeners = new List<ILoadManagerListener>();
        }

        public void GetCurrentLimit()
        {
            var limit = _loadManager.GetStatus().Limit;

            foreach (var loadManagerListener in _listeners)
            {
                loadManagerListener.OnCurrentLimitRetreived(limit);
            }
        }

        public void GetMaxLimit()
        {
            var maxLimit = _loadManager.GetMaxLimit();

            foreach (var loadManagerListener in _listeners)
            {
                loadManagerListener.OnCurrentLimitRetreived(maxLimit);
            }
        }

        public void GetStatus()
        {
            var status = _loadManager.GetStatus();

            foreach (var loadManagerListener in _listeners)
            {
                loadManagerListener.OnLoadStatusRetreived(status);
            }

        }

        public void SetStatus(LoadStatus status)
        {
            _loadManager.SetStatus(status);

            foreach (var loadManagerListener in _listeners)
            {
                loadManagerListener.OnLoadStatusChanged(status);
            }
        }

        public void AddListener(ILoadManagerListener listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(ILoadManagerListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}
