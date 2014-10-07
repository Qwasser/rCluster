using System;

namespace WorkerNode
{
    class SystemInfo : ISystemInfo
    {
        public long GetMemory()
        {
            throw new NotImplementedException();
        }

        public int GetLoad()
        {
            throw new NotImplementedException();
        }
    }
}
