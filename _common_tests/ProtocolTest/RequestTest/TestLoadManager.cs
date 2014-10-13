using _common.Protocol;

namespace _common_tests.ProtocolTest.RequestTest
{
    using _common.NodeInterfaces;
    class TestLoadManager: IAsyncLoadManager
    {
        public static readonly string MaxLimitResult = "maxlimit";
        public static readonly string GetStatusResult = "status";
        public static readonly string CurrentLimitResult = "currentlimit";

        private string _result;

        public string GetResult()
        {
            return _result;
        }
        public void GetCurrentLimit()
        {
            _result = CurrentLimitResult;
        }

        public void GetMaxLimit()
        {
            _result = MaxLimitResult;
        }

        public void GetStatus()
        {
            _result = GetStatusResult;
        }

        public void SetStatus(LoadStatus status)
        {
            _result = status.ToString();
        }

        public void AddListener(ILoadManagerListener listener)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveListener(ILoadManagerListener listener)
        {
            throw new System.NotImplementedException();
        }
    }
}
