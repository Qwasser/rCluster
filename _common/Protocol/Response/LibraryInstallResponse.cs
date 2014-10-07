using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Response
{
    public class LibraryInstallResponse: AbstractResponseClusterMessage
    {
        private readonly string _libName;

        public LibraryInstallResponse(string libName)
        {
            _libName = libName;
        }

        public override void Handle(MasterNodeContext context)
        {
            context.LibraryManagerListener.OnLibraryInstalled(_libName);
        }
    }
}
