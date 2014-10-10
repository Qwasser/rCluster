using System;
using System.Configuration;
using System.Windows.Forms;
using WorkerNode;
using _common.NodeInterfaces;
using _common.Protocol;
using _common.Protocol.Request;
using _common.Protocol.Response;
using _common.SocketConnection;

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
            var rPath = ConfigurationManager.AppSettings["rPath"];
            var redisPort = ConfigurationManager.AppSettings["redisPort"];
            var redisIp = ConfigurationManager.AppSettings["redisIp"];
            var redisQueue = ConfigurationManager.AppSettings["redisQueue"];
            var redisScriptTemplate =  ConfigurationManager.AppSettings["redisScriptTemplate"];
            var loadStatusStr = ConfigurationManager.AppSettings["loadStatus"];

            LoadStatus loadStatus;
            if (!LoadStatus.TryParseString(loadStatusStr, out loadStatus))
            {
                loadStatus.LoadType = DefLoadStatusType;
                loadStatus.Limit = DefaultWorkerLimit;
            }

            IWorkerThreadFactory workerThreadFactory = new WorkerThreadFactory(redisScriptTemplate, rPath);
            IWorkerManager workerManager = new WorkerManager(redisIp, redisPort, redisQueue, workerThreadFactory);

            ILoadManager loadManager = new LoadManager(workerManager, loadStatus);

            ISystemInfo systemInfo = new SystemInfo();

            // Create async wrappers
            var asyncLoadManager = new AsyncLoadManager(loadManager);
            var asyncWorkerManager = new AsyncWorkerManager(workerManager);
            var asyncSystemInfo = new AsyncSystemInfo(systemInfo);
            
            // Create context
            var context = new WorkerNodeContext(null, asyncLoadManager, asyncSystemInfo, asyncWorkerManager);

            // Start listening and message handling in current context
            // Port must be loaded from config file
            WorkerNodeSocket.StartListening(6700, context);

            // Create listeners for response handling
            var remoteWorkerManager = new RemoteWorkerManagerListener(new WorkerNodeSocket());
            var remoteLoadManager = new RemoteLoadManagerListener(new WorkerNodeSocket());
            var remoteSystemInfo = new RemoteSystemInfoListener(new WorkerNodeSocket());

            // Add listeners to async wrappers
            asyncLoadManager.AddListener(remoteLoadManager);
            asyncWorkerManager.AddListener(remoteWorkerManager);
            asyncSystemInfo.AddListener(remoteSystemInfo);

            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(loadManager, workerManager));
        }
    }
}
