using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _common.NodeInterfaces;

namespace _common.Protocol.Response
{
    class RemoteLibraryManagerListener: ILibraryManagerListener
    {
        private readonly IResponseSender _sender;
        public RemoteLibraryManagerListener(IResponseSender sender)
        {
            this._sender = sender;
        }
        public void OnLibraryListRetreived(List<string> libraryList)
        {
            _sender.SendResponse(new LibraryListRetrivedResponse(libraryList));
        }

        public void OnHasLibrary(string libraryName, bool hasLibrary)
        {
            _sender.SendResponse(new HasLibraryResponse(libraryName, hasLibrary));
        }

        public void OnLibraryInstalled(string libraryName)
        {
            _sender.SendResponse(new LibraryInstallResponse(libraryName));
        }

        public void OnFailure(string msg)
        {
            _sender.SendResponse(new LibraryFailureResponse(msg));
        }
    }
}
