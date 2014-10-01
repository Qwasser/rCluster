using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol
{
    public abstract class AbstractClusterMessageHnadler
    {
        public void HandleMessage(ClusterMessage msg)
        {
            switch (msg.Type)
            {
                case MessageType.Error:
                    ParseError(msg);          
                    break;
                case MessageType.Success:
                    ParseSuccess(msg);
                    break;
                case MessageType.SpawnWorkers:
                    ParseSpawnWorkers(msg);
                    break;
                case MessageType.SpawnAllWorkers:
                    ParseSpawnAllWorkers(msg);
                    break;
                case MessageType.StopWorkers:
                    ParseStopWorkers(msg);
                    break;
                case MessageType.StopAllWorkers:
                    ParseStopAllWorkers(msg);
                    break;
                case MessageType.WorkersMemory:
                    ParseWorkersMemory(msg);
                    break;
                case MessageType.WorkersLoad:
                    ParseWorkersLoad(msg);
                    break;
                case MessageType.WorkersCount:
                    ParseWorkersCount(msg);
                    break;
                case MessageType.RedisIp:
                    ParseRedisIp(msg);
                    break;
                case MessageType.TotalLoad:
                    ParseTotalLoad(msg);
                    break;
                case MessageType.TotalMemory:
                    ParseTotalLoad(msg);
                    break;
                case MessageType.LoadStatus:
                    ParseLoadStatus(msg);
                    break;
                case MessageType.CurrentWorkerLimit:
                    ParseCurrentWorkerLimit(msg);
                    break;
                case MessageType.MaximumWorkerLimit:
                    ParseMaximumWorkerLimit(msg);
                    break;
                case MessageType.LibrariesList:
                    ParseLibrariesList(msg);
                    break;
                case MessageType.HasLibrary:
                    ParseHasLibrary(msg);
                    break;
                case MessageType.InstallLibrary:
                    ParseInstallLibrary(msg);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }          
        }

        abstract public void ParseError(ClusterMessage msg);
        abstract public void ParseSuccess(ClusterMessage msg);

        abstract public void ParseSpawnWorkers(ClusterMessage msg);
        abstract public void ParseSpawnAllWorkers(ClusterMessage msg);
        abstract public void ParseStopWorkers(ClusterMessage msg);
        abstract public void ParseStopAllWorkers(ClusterMessage msg);
        abstract public void ParseWorkersMemory(ClusterMessage msg);
        abstract public void ParseWorkersLoad(ClusterMessage msg);
        abstract public void ParseWorkersCount(ClusterMessage msg);
        abstract public void ParseRedisIp(ClusterMessage msg);


        abstract public void ParseTotalLoad(ClusterMessage msg);
        abstract public void ParseTotalMemory(ClusterMessage msg);
        abstract public void ParseLoadStatus(ClusterMessage msg);
        abstract public void ParseCurrentWorkerLimit(ClusterMessage msg);
        abstract public void ParseMaximumWorkerLimit(ClusterMessage msg);

        abstract public void ParseLibrariesList(ClusterMessage msg);
        abstract public void ParseHasLibrary(ClusterMessage msg);
        abstract public void ParseInstallLibrary(ClusterMessage msg);
    }
}
