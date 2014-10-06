using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerNode
{
    public class WorkerThread : RThread
    {
        public WorkerThread(string script, string rPath) : base(script, rPath)
        {
        }
    }
}
