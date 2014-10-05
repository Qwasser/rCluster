using _common.NodeInterfaces;

namespace _common_tests.ProtocolTest.RequestTest
{
    class TestLibraryManager: IAsyncLibraryManager
    {
        public static readonly string HasLibraryResult = "haslibrary";
        public static readonly string GetLibraryListResult = "librarylist";
        public static readonly string InstallLibraryResult = "installlibrary";

        private string _result;
        public string GetResult()
        {
            return _result;
        }
        public void HasLibrary(string libraryName)
        {
            _result = HasLibraryResult + libraryName;
        }

        public void GetLibraryList()
        {
            _result = GetLibraryListResult;
        }

        public void InstallLibrary(string libraryName)
        {
            _result = InstallLibraryResult + libraryName;
        }
    }
}
