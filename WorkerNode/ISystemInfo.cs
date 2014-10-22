using System;

namespace WorkerNode
{
    public abstract class ISystemInfo
    {
        public abstract float GetMemory();

        public abstract float GetLoad();

        public Action<Tuple<float, float>> InfoChange;
    }
}
