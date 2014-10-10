using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _common.Protocol.Response;
using _common.SocketConnection;
using _common.Protocol;

namespace _common_tests.ConnectionTest
{
    public class StringResponseHandler: IResponseHandler
    {

        public string Result { get; private set; }
        public void HandleResponse(AbstractResponseClusterMessage msg)
        {
            Result = msg.ToString();
        }
    }
}
