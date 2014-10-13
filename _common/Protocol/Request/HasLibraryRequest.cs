using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Request
{
    public class HasLibraryRequest: AbstractRequestClusterMessage
    {
        private readonly string _libraryName;

        public HasLibraryRequest(string libraryName)
        {
            _libraryName = libraryName;
        }

        public override void Handle(WorkerNodeContext context)
        {
            context.LibraryManager.HasLibrary(_libraryName);
        }
    }
}
