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
        void OnTotalMemoryRetreived(float memory);
        void OnTotalLoadRetreived(float load);
    }
}
