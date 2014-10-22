using System;
using System.Diagnostics;

namespace WorkerNode
{
    public class SystemInfo : ISystemInfo
    {
        private const int TimerInterval = 1000;

        private PerformanceCounter _cpuCounter;
        private PerformanceCounter _ramCounter;

        private System.Timers.Timer _cpuLoadTread;

        private float _cpuLoad;

        public SystemInfo()
        {
            _cpuCounter = new PerformanceCounter();

            _cpuCounter.CategoryName = "Processor";
            _cpuCounter.CounterName = "% Processor Time";
            _cpuCounter.InstanceName = "_Total"; 

            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");

            _cpuLoad = 0;

            _cpuLoadTread = new System.Timers.Timer()
            {
                Interval = TimerInterval,
                Enabled = true
            };

            _cpuLoadTread.Elapsed += (sender, args) =>
            {
                UpdateCpuLoad();

                InfoChange(new Tuple<float, float>(GetLoad(), GetMemory()));
            };

            _cpuLoadTread.Start();
        }

        public override float GetMemory()
        {
            return _ramCounter.NextValue();
        }

        public override float GetLoad()
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
