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
            string rPath = ConfigurationManager.AppSettings["rPath"];
            string redisPort = ConfigurationManager.AppSettings["redisPort"];
            string redisIp = ConfigurationManager.AppSettings["redisIp"];
            string redisQueue = ConfigurationManager.AppSettings["redisQueue"];
            string redisScriptTemplate =  ConfigurationManager.AppSettings["redisScriptTemplate"];
            string loadStatusStr = ConfigurationManager.AppSettings["loadStatus"];

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
