using _common.NodeInterfaces;
namespace _common_tests.ProtocolTest.RequestTest
{
    class TestSystemInfo: IAsyncSystemInfo
    {
        public static readonly string SystemMemoryResult = "systemmemory";
        public static readonly string SystemLoadResult = "systemload";

        private string _result;
        public string GetResult()
        {
            return _result;
        }
        public void GetSystemMemory()
        {
            _result = SystemMemoryResult;
        }

        public void GetSystemLoad()
        {
            _result = SystemLoadResult;
        }
    }
}
