using _common.NodeInterfaces;

namespace _common.Protocol.Request
{
    class RemoteLibraryManager: IAsyncLibraryManager
    {
        private readonly IRequestSender _sender;
        public RemoteLibraryManager(IRequestSender sender)
        {
            _sender = sender;
        }
        public void HasLibrary(string libraryName)
        {
            _sender.SendRequest(new HasLibraryRequest(libraryName));
        }

        public void GetLibraryList()
        {
            _sender.SendRequest(new GetLibraryListRequest());
        }

        public void InstallLibrary(string libraryName)
        {
            _sender.SendRequest(new InstallLibraryRequest(libraryName));
        }
    }
}
