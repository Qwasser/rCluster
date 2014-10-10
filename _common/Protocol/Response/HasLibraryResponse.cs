
using System;

namespace _common.Protocol.Response
{
    [Serializable]
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
