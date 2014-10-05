namespace _common.Protocol
{
    public abstract class AbstractClusterRequestHandler : AbstractClusterMessageHnadler
    {
        public override void ParseError(ClusterMessage msg)
        {
            HandleError(msg.Data);   
        }

        public override void ParseSuccess(ClusterMessage msg)
        {
            HandleSuccess(msg.Data);
        }

        public override void ParseSpawnWorkers(ClusterMessage msg)
        {
            HandleSpawnWorkers(MessageDataUtils.GetIntFromData(msg.Data));
        }

        public override void ParseSpawnAllWorkers(ClusterMessage msg)
        {
            HandleSpawnAllWorkers();
        }

        public override void ParseStopWorkers(ClusterMessage msg)
        {
            HandleStopWorkers(MessageDataUtils.GetIntFromData(msg.Data));
        }
        public override void ParseStopAllWorkers(ClusterMessage msg)
        {
            HandleStopAllWorkers();
        }

        public override void ParseWorkersMemory(ClusterMessage msg)
        {
            HandleWorkersMemory();
        }

        public override void ParseWorkersLoad(ClusterMessage msg)
        {
            HandleWorkersLoad();
        }

        public override void ParseWorkersCount(ClusterMessage msg)
        {
            HandleWorkersCount();
        }

        public override void ParseRedisIp(ClusterMessage msg)
        {
            HandleRedisIp(msg.Data);
        }


        public override void ParseTotalLoad(ClusterMessage msg)
        {
            HandleTotalLoad();
        }

        public override void ParseTotalMemory(ClusterMessage msg)
        {
            HandleTotalMemory();
        }

        public override void ParseLoadStatus(ClusterMessage msg)
        {
            HandleLoadStatus();
        }

        public override void ParseSetLoadStatus(ClusterMessage msg)
        {
            LoadStatus s;
            LoadStatus.TryParseString(msg.Data, out s);

        }
        public override void ParseCurrentWorkerLimit(ClusterMessage msg)
        {
            HandleCurrentWorkerLimit();
        }
        public override void ParseMaximumWorkerLimit(ClusterMessage msg)
        {
            HandleMaximumWorkerLimit();
        }

        public override void ParseLibrariesList(ClusterMessage msg)
        {
            HandleLibrariesList();
        }

        public override void ParseHasLibrary(ClusterMessage msg)
        {
            HandleHasLibrary(msg.Data);
        }

        public override void ParseInstallLibrary(ClusterMessage msg)
        {
            HandleInstallLibrary(msg.Data);
        }

        // handler functions
        abstract public void HandleError(string msg);
        abstract public void HandleSuccess(string msg);

        abstract public void HandleSpawnWorkers(int count);
        abstract public void HandleSpawnAllWorkers();
        abstract public void HandleStopWorkers(int count);
        abstract public void HandleStopAllWorkers();
        abstract public void HandleWorkersMemory();
        abstract public void HandleWorkersLoad();
        abstract public void HandleWorkersCount();
        abstract public void HandleRedisIp(string ip);


        abstract public void HandleTotalLoad();
        abstract public void HandleTotalMemory();
        abstract public void HandleLoadStatus();
        abstract public void HandleSetLoadStatus(LoadStatus status);
        abstract public void HandleCurrentWorkerLimit();
        abstract public void HandleMaximumWorkerLimit();

        abstract public void HandleLibrariesList();
        abstract public void HandleHasLibrary(string libraryName);
        abstract public void HandleInstallLibrary(string libraryName);
    }
}
