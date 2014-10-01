using System.Collections.Generic;

namespace _common.Protocol
{
    abstract public class AbstractClusterResponseHandlers : AbstractClusterMessageHnadler
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

        }

        public override void ParseSpawnAllWorkers(ClusterMessage msg)
        {

        }

        public override void ParseStopWorkers(ClusterMessage msg)
        {

        }
        public override void ParseStopAllWorkers(ClusterMessage msg)
        {

        }

        public override void ParseWorkersMemory(ClusterMessage msg)
        {
            HandleWorkersMemory(MessageDataUtils.GetIntFromData(msg.Data));
        }

        public override void ParseWorkersLoad(ClusterMessage msg)
        {
            HandleWorkersLoad(MessageDataUtils.GetIntFromData(msg.Data));
        }

        public override void ParseWorkersCount(ClusterMessage msg)
        {

            HandleWorkersCount(MessageDataUtils.GetIntFromData(msg.Data));
        }

        public override void ParseRedisIp(ClusterMessage msg)
        {
            HandleRedisIp(msg.Data);
        }


        public override void ParseTotalLoad(ClusterMessage msg)
        {
            HandleTotalLoad(MessageDataUtils.GetIntFromData(msg.Data));
        }

        public override void ParseTotalMemory(ClusterMessage msg)
        {
            HandleTotalMemory(MessageDataUtils.GetIntFromData(msg.Data));
        }

        public override void ParseLoadStatus(ClusterMessage msg)
        {
            HandleLoadStatus(msg.Data);
        }

        public override void ParseCurrentWorkerLimit(ClusterMessage msg)
        {
            HandleCurrentWorkerLimit(MessageDataUtils.GetIntFromData(msg.Data));
        }
        public override void ParseMaximumWorkerLimit(ClusterMessage msg)
        {
            HandleMaximumWorkerLimit(MessageDataUtils.GetIntFromData(msg.Data));
        }

        public override void ParseLibrariesList(ClusterMessage msg)
        {
            HandleLibrariesList(MessageDataUtils.GetSemicolonListFromData(msg.Data));
        }

        public override void ParseHasLibrary(ClusterMessage msg)
        {
            HandleHasLibrary(msg.Data);
        }

        public override void ParseInstallLibrary(ClusterMessage msg)
        {
            
        }

        // handler functions
        abstract public void HandleError(string msg);
        abstract public void HandleSuccess(string msg);

        abstract public void HandleWorkersMemory(int memory);
        abstract public void HandleWorkersLoad(int load);
        abstract public void HandleWorkersCount(int count);
        abstract public void HandleRedisIp(string ip);


        abstract public void HandleTotalLoad(int load);
        abstract public void HandleTotalMemory(int memory);
        abstract public void HandleLoadStatus(string status);
        abstract public void HandleCurrentWorkerLimit(int limit);
        abstract public void HandleMaximumWorkerLimit(int maxLimit);

        abstract public void HandleLibrariesList(List<string> libs);
        abstract public void HandleHasLibrary(bool hasLibrary, string libraryName);
    }
}
