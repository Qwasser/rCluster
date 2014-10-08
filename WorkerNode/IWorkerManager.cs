using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerNode
{
    interface IWorkerManager
    {
        void AddWorkers(int n);

        void RemoveWorkers(int n);

        void AddAllWorkers();

        void RemoveAllWorkers();

        void SetWorkersLimit(int limit);

        int GetWorkersCount();

        //void addListener(IWorkerManagerListener)
    }
}
