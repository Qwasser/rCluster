using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.NodeInterfaces
{
    public interface IWorkerManagerListener
    {
        void OnCountRetreived(int count);
        void OnError(string error);
        void OnRedisIpRetrived(string ip);
        void OnWorkersLoadRetreived(long load);
        void OnWorkersMemoryRetreived(long memory);
    }
}
