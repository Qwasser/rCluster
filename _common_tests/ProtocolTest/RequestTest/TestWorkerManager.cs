using _common.NodeInterfaces;

namespace _common_tests.ProtocolTest.RequestTest
{
    class TestWorkerManager: IAsyncWorkerManager
    {
        public static readonly string AddWorkersResult = "addworkers";
        public static readonly string StopWorkersResult = "stopworkers";
        public static readonly string AddAllWorkersResult = "addworkers";
        public static readonly string StopAllWorkersResult = "stopworkers";
        public static readonly string GetWorkersCountResult = "getworkerscount";
        public static readonly string SetRedisIpResult = "setredisip";
        public static readonly string GetWorkersMemoryResult = "getworkersmemory";
        public static readonly string GetWorkersLoadResult = "getworkersload";
        private string _result;
        public string GetResult()
        {
            return _result;
        }
        public void GetWorkersCount()
        {
            _result = GetWorkersCountResult;
        }

        public void AddWorkers(int n)
        {
            _result = AddWorkersResult + n;
        }

        public void RemoveWorkers(int n)
        {
            _result = StopWorkersResult + n;
        }

        public void AddAllWorkers()
        {
            _result = AddAllWorkersResult;
        }

        public void RemoveAllWorkers()
        {
            _result = StopAllWorkersResult;
        }

        public void SetRedisIp(string ip)
        {
            _result = SetRedisIpResult + ip;
        }

        public void GetWorkersMemory()
        {
            _result = GetWorkersMemoryResult;
        }

        public void GetWorkersLoad()
        {
            _result = GetWorkersLoadResult;
        }
    }
}
