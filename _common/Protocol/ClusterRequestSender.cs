using System;

using System.Globalization;

namespace _common.Protocol
{
    public class ClusterRequestSender
    {
        private readonly IMessageSender _sender;

        public ClusterRequestSender(IMessageSender sender)
        {
            _sender = sender;
        }

        public void SendError(string msg)
        {
            var m = new ClusterMessage {Data = msg, Type = MessageType.Error};
            _sender.BeginSendMessage(m);
        }

        public void SendSuccess(string msg)
        {
            var m = new ClusterMessage { Data = msg, Type = MessageType.Success };
            _sender.BeginSendMessage(m);
        }

        public void SendSpawnWorkers(int count)
        {
            var m = new ClusterMessage { Data = count.ToString(CultureInfo.InvariantCulture), Type = MessageType.SpawnWorkers };
            _sender.BeginSendMessage(m);
        }

        public void SendSpawnAllWorkers()
        {
            var m = new ClusterMessage { Data = String.Empty, Type = MessageType.SpawnAllWorkers };
            _sender.BeginSendMessage(m);
        }

        public void SendStopWorkers(int count)
        {
            var m = new ClusterMessage { Data = count.ToString(CultureInfo.InvariantCulture), Type = MessageType.StopWorkers };
            _sender.BeginSendMessage(m);
        }
        public void SendStopAllWorkers()
        {
            var m = new ClusterMessage { Data = String.Empty, Type = MessageType.StopAllWorkers };
            _sender.BeginSendMessage(m);
        }

        public void SendWorkersMemory()
        {
            var m = new ClusterMessage { Data = String.Empty, Type = MessageType.WorkersMemory };
            _sender.BeginSendMessage(m);   
        }

        public void SendWorkersLoad()
        {
            var m = new ClusterMessage { Data = String.Empty, Type = MessageType.WorkersLoad };
            _sender.BeginSendMessage(m);   
        }

        public void SendWorkersCount()
        {
            var m = new ClusterMessage { Data = String.Empty, Type = MessageType.WorkersCount };
            _sender.BeginSendMessage(m);   
        }

        public void SendRedisIp(string ip)
        {
            var m = new ClusterMessage { Data = ip, Type = MessageType.RedisIp };
            _sender.BeginSendMessage(m);   
        }


        public void SendTotalLoad()
        {
            var m = new ClusterMessage { Data = String.Empty, Type = MessageType.TotalLoad };
            _sender.BeginSendMessage(m);   
        }

        public void SendTotalMemory()
        {
            var m = new ClusterMessage { Data = String.Empty, Type = MessageType.TotalMemory };
            _sender.BeginSendMessage(m);   
        }

        public void SendLoadStatus()
        {
            var m = new ClusterMessage { Data = String.Empty, Type = MessageType.LoadStatus };
            _sender.BeginSendMessage(m);   
        }

        public void SendSetLoadStatus(LoadStatus status)
        {
            var m = new ClusterMessage { Data = status.ToString(), Type = MessageType.SetLoadStatus };
            _sender.BeginSendMessage(m);   
        }
        public void SendCurrentWorkerLimit()
        {
            var m = new ClusterMessage { Data = String.Empty, Type = MessageType.CurrentWorkerLimit };
            _sender.BeginSendMessage(m);
        }

        public void SendMaximumWorkerLimit()
        {
            var m = new ClusterMessage { Data = String.Empty, Type = MessageType.MaximumWorkerLimit };
            _sender.BeginSendMessage(m);
        }

        public void SendLibrariesList()
        {
            var m = new ClusterMessage { Data = String.Empty, Type = MessageType.LibrariesList };
            _sender.BeginSendMessage(m);
        }

        public void SendHasLibrary(string libraryName)
        {
            var m = new ClusterMessage { Data = libraryName, Type = MessageType.HasLibrary };
            _sender.BeginSendMessage(m);
        }
        public void SendInstallLibrary(string libraryName)
        {
            var m = new ClusterMessage { Data = libraryName, Type = MessageType.InstallLibrary };
            _sender.BeginSendMessage(m);
        }
    }
}
