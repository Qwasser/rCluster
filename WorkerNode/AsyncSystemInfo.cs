﻿using System;
using System.Collections.Generic;
using _common.NodeInterfaces;

namespace WorkerNode
{
    public class AsyncSystemInfo : IAsyncSystemInfo
    {
        private readonly ISystemInfo _systemInfo;
        private readonly List<ISystemInfoListener> _listeners;  


        public AsyncSystemInfo(ISystemInfo systemInfo)
        {
            _systemInfo = systemInfo;
            _systemInfo.InfoChange += OnInfoChange;

            _listeners = new List<ISystemInfoListener>();
        }


        private void OnInfoChange(Tuple<float, float> info)
        {
            foreach (var listener in _listeners)
            {
                listener.OnTotalLoadRetreived(info.Item1);
            }

            foreach (var listener in _listeners)
            {
                listener.OnTotalMemoryRetreived(info.Item2);
            }
        }

        public void GetSystemMemory()
        {
            var memory = _systemInfo.GetMemory();

            foreach (var listener in _listeners)
            {
                listener.OnTotalMemoryRetreived(memory);
            }
        }

        public void GetSystemLoad()
        {
            var load = _systemInfo.GetLoad();

            foreach (var listener in _listeners)
            {
                listener.OnTotalLoadRetreived(load);
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
