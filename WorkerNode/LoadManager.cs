using System;
using System.Linq;
using System.Management;
using _common.Protocol;

namespace WorkerNode
{
    class LoadManager : ILoadManager
    {
        private readonly int _maxLimit;
        private readonly IWorkerManager _workerManager;

        private LoadStatus _status;

        public LoadManager(IWorkerManager workerManager, LoadStatus status)
        {
            _workerManager = workerManager;
            _status = status;
            _maxLimit = CountCores();

            ApplyLoadStatus();
        }


        public int GetMaxLimit()
        {
            return _maxLimit;
        }

        public LoadStatus GetStatus()
        {
            return _status;
        }

        public void SetStatus(LoadStatus status)
        {
            _status = status;

            ApplyLoadStatus();
        }

        private void ApplyLoadStatus()
        {
            switch (_status.LoadType)
            {
                case LoadStatusType.Free:
                    {
                        _workerManager.SetWorkersLimit(_maxLimit);
                        break;
                    }

                case LoadStatusType.Limited:
                    {
                        _workerManager.SetWorkersLimit(Math.Min(_maxLimit, _status.Limit));
                        break;
                    }
                case LoadStatusType.Locked:
                    {
                        _workerManager.SetWorkersLimit(0);
                        break;
                    }
            }
        }

        private int CountCores()
        {
            return new ManagementObjectSearcher("Select * from Win32_Processor").Get().Cast<ManagementBaseObject>().Sum(item => int.Parse(item["NumberOfCores"].ToString()));
        }
    }
}
