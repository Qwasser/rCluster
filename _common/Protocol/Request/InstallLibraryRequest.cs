using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Request
{
    class InstallLibraryRequest: AbstractRequestClusterMessage
    {
        private readonly string _libraryName;

        public InstallLibraryRequest(string libraryName)
        {
            _libraryName = libraryName;
        }

        public override void Handle(WorkerNodeContext context)
        {
            context.LibraryManager.InstallLibrary(_libraryName);
        }
    }
}
