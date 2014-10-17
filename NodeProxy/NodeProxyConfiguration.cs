using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeProxy
{
    public class NodeProxyConfiguration
    {
        public string Name { get; private set; }
        
        public string Ip { get; private set; }

        public int Port { get; private set; }

        public NodeProxyConfiguration(string name, string ip, int port)
        {
            Port = port;
            Ip = ip;
            Name = name;
        }
    }
}
