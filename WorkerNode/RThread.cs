using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace WorkerNode
{
    public class RThread
    {
        private readonly ProcessStartInfo rStartInfo;

        public Action<String> OnSuccess;

        public Action<String> OnFailure;

        private Process _process;
        private bool _disposed;

        public RThread(String script, String rPath)
        {
            rStartInfo = new ProcessStartInfo
            {
                
                    FileName = rPath,
                    Arguments = script,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                
            };

            _process = Process.Start(rStartInfo);
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
