using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterNodeApp
{
    class NodeConnectionInfo : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return this["name"].ToString(); }
        }

        [ConfigurationProperty("ip")]
        public string Price
        {
            get { return this["ip"].ToString(); }
        }

        [ConfigurationProperty("port")]
        public int Port
        {
            get { return Convert.ToInt32(this["ip"]); }
        }
    }

    class NodeConnectionInfoCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new NodeConnectionInfo();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((NodeConnectionInfo) element).Name;
        }
    }

    class NodeProxyConfigurationsSection : ConfigurationSection
    {
        [ConfigurationProperty("NodesInfo")]
        public NodeConnectionInfoCollection NodesInfo
        {
            get { return (NodeConnectionInfoCollection)this["NodesInfo"]; }
        }
    }
}
