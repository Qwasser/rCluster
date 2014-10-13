using System;
using _common;
using _common.Protocol;

namespace WorkerNode
{
    public abstract class ILoadManager
    {
        public abstract int GetMaxLimit();
        public abstract LoadStatus GetStatus();
        public abstract void SetStatus(LoadStatus status);
        public Action<LoadStatus> LoadStatusChanged;
    }
}
