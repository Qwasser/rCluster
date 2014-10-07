using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Response
{
    public class LibraryListRetrivedResponse: AbstractResponseClusterMessage
    {
        private readonly List<string> _libs;

        public LibraryListRetrivedResponse(List<string> libs)
        {
            _libs = libs;
        }


        public override void Handle(MasterNodeContext context)
        {
            context.LibraryManagerListener.OnLibraryListRetreived(_libs);
        }
    }
}
