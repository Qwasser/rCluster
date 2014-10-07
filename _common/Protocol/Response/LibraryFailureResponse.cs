using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Response
{
    public class LibraryFailureResponse: AbstractResponseClusterMessage
    {
        private readonly string _msg;

        public LibraryFailureResponse(string msg)
        {
            this._msg = msg;
        }

        public override void Handle(MasterNodeContext context)
        {
            context.LibraryManagerListener.OnFailure(_msg);
        }
    }
}
