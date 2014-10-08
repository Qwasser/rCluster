using System.Diagnostics;

namespace WorkerNode
{
    public class SystemInfo : ISystemInfo
    {
        private const int TimerInterval = 1000;

        private PerformanceCounter _cpuCounter;
        private PerformanceCounter _ramCounter;

        private System.Timers.Timer _cpuLoadTread;

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

            _cpuLoadTread = new System.Timers.Timer()
            {
                Interval = TimerInterval,
                Enabled = true
            };

            _cpuLoadTread.Elapsed += (sender, args) => UpdateCpuLoad();

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

        private void UpdateCpuLoad()
        {
            _cpuLoad = _cpuCounter.NextValue();
        }

        ~SystemInfo()
        {
            _cpuLoadTread.Stop();
        }
    }
}
