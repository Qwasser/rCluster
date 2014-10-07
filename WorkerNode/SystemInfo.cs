using System.Diagnostics;
using System.Threading;

namespace WorkerNode
{
    public class SystemInfo : ISystemInfo
    {
        private PerformanceCounter _cpuCounter;
        private PerformanceCounter _ramCounter;

        private Thread _cpuLoadTread;

        private bool _aborted;

        private float _cpuLoad;

        public SystemInfo()
        {
            _cpuCounter = new PerformanceCounter();

            _cpuCounter.CategoryName = "Processor";
            _cpuCounter.CounterName = "% Processor Time";
            _cpuCounter.InstanceName = "_Total"; 

            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");

            _aborted = false;
            _cpuLoad = 0;

            _cpuLoadTread = new Thread(UpdateCPULoad);
            _cpuLoadTread.Start();
        }


        public float GetMemory()
        {
            return _ramCounter.NextValue();
        }

        public float GetLoad()
        {
            return _cpuLoad;
        }

        private void UpdateCPULoad()
        {
            while (!_aborted)
            {
                _cpuCounter.NextValue();
                Thread.Sleep(1000);

                _cpuLoad = _cpuCounter.NextValue();
            }
        }

        private void Dispode()
        {
            _aborted = true;
            _cpuLoadTread.Join();
        }

        ~SystemInfo()
        {
            Dispode();
        }
    }
}
