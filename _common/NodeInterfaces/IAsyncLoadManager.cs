using System;
using System.Collections.Generic;
using _common.Protocol;

namespace _common.NodeInterfaces
{
    /// <summary>
    /// Asynchronious interface for load managing
    /// </summary>
    public interface IAsyncLoadManager
    {
        void GetCurrentLimit();
        void GetMaxLimit();
        void GetStatus();
        void SetStatus(LoadStatus status);

        void AddListener(ILoadManagerListener listener);
        void RemoveListener(ILoadManagerListener listener);
    }
}
