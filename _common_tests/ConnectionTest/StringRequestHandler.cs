using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _common.Protocol.Request;

namespace _common_tests.ConnectionTest
{
    public class StringRequestHandler : IRequestHandler
    {
        public string Result { get; private set; }
        public void HandleRequest(AbstractRequestClusterMessage msg)
        {
            Result = msg.ToString();
        }
    }
}
