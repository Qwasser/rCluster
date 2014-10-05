using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.NodeInterfaces
{
    public interface ISystemInfoListener
    {
        void OnMemoryRetreived(long memory);
        void OnLoadRetreived(long load);
    }
}
