using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _common.NodeInterfaces;

namespace WorkerNode
{
    class AsyncSystemInfo : IAsyncSystemInfo
    {
        private readonly ISystemInfo _systemInfo;
        private readonly List<ISystemInfoListener> _listeners;  


        public AsyncSystemInfo(ISystemInfo systemInfo)
        {
            _systemInfo = systemInfo;
            _listeners = new List<ISystemInfoListener>();
        }


        public void GetSystemMemory()
        {
            var memory = _systemInfo.GetMemory();

            foreach (var listener in _listeners)
            {
                listener.OnMemoryRetreived(memory);
            }
        }

        public void GetSystemLoad()
        {
            var load = _systemInfo.GetLoad();

            foreach (var listener in _listeners)
            {
                listener.OnLoadRetreived(load);
            }
        }

        public void AddListener(ISystemInfoListener listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(ISystemInfoListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}
