using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _common.Protocol;

namespace WorkerNode
{
    public abstract class IWorkerManager
    {
        public abstract void AddWorkers(int n);

        public abstract void RemoveWorkers(int n);

        public abstract void AddAllWorkers();

        public abstract void RemoveAllWorkers();

        public abstract void SetWorkersLimit(int limit);

        public abstract int GetWorkersCount();

        public abstract float GetUsedMemory();

        public abstract float GetTotalLoad();

        public Action<int> WorkersCountChange;

        public Action<Tuple<float, float>> WorkersLoadUpdated;

        //void addListener(IWorkerManagerListener)
    }
}
