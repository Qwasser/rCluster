using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _common.NodeInterfaces;

namespace _common_tests.ProtocolTest.RequestTest
{
    class TestWorkerManager: IAsyncWorkerManager
    {
        public void GetWorkersCount()
        {
            throw new NotImplementedException();
        }

        public void AddWorkers(int n)
        {
            throw new NotImplementedException();
        }

        public void RemoveWorkers(int n)
        {
            throw new NotImplementedException();
        }

        public void AddAllWorkers()
        {
            throw new NotImplementedException();
        }

        public void RemoveAllWorkers()
        {
            throw new NotImplementedException();
        }

        public void SetRedisIp(string ip)
        {
            throw new NotImplementedException();
        }

        public void GetWorkersMemory()
        {
            throw new NotImplementedException();
        }

        public void GetWorkersLoad()
        {
            throw new NotImplementedException();
        }
    }
}
