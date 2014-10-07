using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
