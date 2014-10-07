using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Response
{
    public class HasLibraryResponse: AbstractResponseClusterMessage
    {
        private readonly string _libName;
        private readonly bool _hasLibrary;

        public HasLibraryResponse(string libName, bool hasLibrary)
        {
            _libName = libName;
            _hasLibrary = hasLibrary;
        }

        public override void Handle(MasterNodeContext context)
        {
            context.LibraryManagerListener.OnHasLibrary(_libName, _hasLibrary);
        }
    }
}
