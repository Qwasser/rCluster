using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol.Request
{
    public interface IRequestSender
    {
        void SendRequest(AbstractRequestClusterMessage msg);
    }
}
