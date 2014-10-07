using System;
using System.Diagnostics;

namespace WorkerNode
{
    public class RThread
    {
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

                if (process != null && process.ExitCode != 0)
                {
                    OnFailure(new Tuple<int, string>(Id, args.ToString()));
                }
                else
                {
                    OnSuccess(new Tuple<int, string>(Id, args.ToString()));
                }
            };

            _process.StartInfo = rStartInfo;

            _process.Start();
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
        }

        ~RThread()
        {
            Dispose();
        }
    }
}
