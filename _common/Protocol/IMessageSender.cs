using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol
{
    public interface IMessageSender
    {
        void SendMessage(ClusterMessage msg);
        void BeginSendMessage(ClusterMessage msg);
    }
}
