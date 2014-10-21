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
            get { return _ramCounter.NextValue() / 1024 / 1024; }
        }

        private System.Timers.Timer _cpuLoadTread;
        private PerformanceCounter _cpuCounter;
        private PerformanceCounter _ramCounter;

        public float CpuLoad { get; private set; }

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
            _cpuCounter = new PerformanceCounter("Process", "% Processor Time", _process.ProcessName);

            _cpuLoadTread = new System.Timers.Timer()
            {
                Interval = TimerInterval,
                Enabled = true
            };

            _cpuLoadTread.Elapsed += (sender, args) =>
            {
                try
                {
                    CpuLoad = _cpuCounter.NextValue();
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
