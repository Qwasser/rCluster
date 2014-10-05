using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Request
{
    class GetLibraryListRequest: AbstractRequestClusterMessage
    {
        public override void Handle(WorkerNodeContext context)
        {
            context.LibraryManager.GetLibraryList();
        }
    }
}
