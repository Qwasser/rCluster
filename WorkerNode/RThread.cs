using System;
using System.Diagnostics;

namespace WorkerNode
{
    public class RThread
    {
        private const int TimerInterval = 1000;

        public Action<Tuple<int, string>> OnSuccess;

        public Action<Tuple<int, string>> OnMessage;

        public Action<Tuple<int, string>> OnFailure;

        private readonly Process _process;
        private bool _disposed;

        public readonly int Id;

        public bool HasExidet
        {
            get { return _process.HasExited; }
        }

        public float Memory
        {
            get
            {
                if (! _process.HasExited)
                {
                    return _ramCounter.NextValue()/1024/1024;
                }
                else
                {
                    return 0;
                }
            }
        }

        private System.Timers.Timer _cpuLoadTread;
        private PerformanceCounter _cpuCounter;
        private PerformanceCounter _ramCounter;

        public double CpuLoad { get; private set; }

        private double _oldCPUTime = 0;
        private double _currentCPUTime = 0;

        public RThread(String script, String rPath, int id)
        {
            Id = id;

            var rStartInfo = new ProcessStartInfo
            {
                
                FileName = rPath,
                Arguments = script,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
                
            };

            _process = new Process();

            _process.ErrorDataReceived += (sender, args) => OnFailure(new Tuple<int, string>(Id, args.ToString()));
            _process.OutputDataReceived += (sender, args) => OnMessage(new Tuple<int, string>(Id, args.ToString()));
            
            _process.Exited += (sender, args) => 
            { 
                var process = sender as Process;
                
                if (!_disposed)
                {
                    if (process != null && process.ExitCode != 0)
                    {
                        OnFailure(new Tuple<int, string>(Id, args.ToString()));
                    }
                    else
                    {
                        OnSuccess(new Tuple<int, string>(Id, args.ToString()));
                    }
                }
            };

            _process.StartInfo = rStartInfo;
            _process.Start();

            CpuLoad = 0f;
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");


            
            _cpuLoadTread = new System.Timers.Timer()
            {
                Interval = TimerInterval,
                Enabled = true
            };
            
            _cpuLoadTread.Elapsed += (sender, args) =>
            {
                try
                {
                    _oldCPUTime = _currentCPUTime;
                    _currentCPUTime = _process.TotalProcessorTime.TotalMilliseconds;
                    CpuLoad = (_currentCPUTime - _oldCPUTime)/TimerInterval;
                    CpuLoad = CpuLoad*_cpuCounter.NextValue();
                    CpuLoad = CpuLoad/4;
                }
                catch (Exception e)
                {
                    var timer = sender as System.Timers.Timer;

                    if (timer != null) timer.Stop();
                }
            };

            _cpuLoadTread.Start();

            _ramCounter = new PerformanceCounter
            {
                CategoryName = "Process",
                CounterName = "Working Set",
                InstanceName = _process.ProcessName
            };

            _disposed = false;
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            if (!_process.HasExited)
            {
                _process.CloseMainWindow();
                _process.Kill();
            }

            _disposed = true;
            GC.SuppressFinalize(this);

            _cpuLoadTread.Stop();
        }

        ~RThread()
        {
            Dispose();
        }
    }
}
