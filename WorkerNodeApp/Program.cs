using System;
using System.Configuration;
using System.Windows.Forms;
using WorkerNode;
using _common.Protocol;

namespace WorkerNodeApp
{
    static class Program
    {
        private const int DefaultWorkerLimit = 4;
        private const LoadStatusType DefLoadStatusType = LoadStatusType.Free;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string rPath = @"C:\Program Files\R\R-3.1.1\bin\x64\Rscript";//ConfigurationManager.AppSettings["rPath"];
            string redisPort = "6379";//ConfigurationManager.AppSettings["redisPort"];
            string redisIp = "127.0.0.1";//ConfigurationManager.AppSettings["redisIp"];
            string redisQueue = "jobs";//ConfigurationManager.AppSettings["redisQueue"];
            string redisScriptTemplate = " --slave -e \"require(doRedis);redisWorker(host = '{0}', port = {1}, queue='{2}')\" ";//ConfigurationManager.AppSettings["redisScriptTemplate"];
            string loadStatusStr = "Free;4";//ConfigurationManager.AppSettings["loadStatus"];

            LoadStatus loadStatus;
            if (!LoadStatus.TryParseString(loadStatusStr, out loadStatus))
            {
                loadStatus.LoadType = DefLoadStatusType;
                loadStatus.Limit = DefaultWorkerLimit;
            }

            IWorkerThreadFactory workerThreadFactory = new WorkerThreadFactory(redisScriptTemplate, rPath);
            IWorkerManager workerManager = new WorkerManager(redisIp, redisPort, redisQueue, workerThreadFactory);

            ILoadManager loadManager = new LoadManager(workerManager, loadStatus);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(loadManager, workerManager));
        }
    }
}
