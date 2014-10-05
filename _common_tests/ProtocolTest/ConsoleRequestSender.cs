using System;

using System.Globalization;

using _common.Protocol;

namespace _common_tests.ProtocolTest
{
    class ConsoleRequestSender: AbstractClusterRequestHandler, IMessageSender
    {
        private string _result = String.Empty;

        public string GetLastMessage()
        {
            return _result;
        }
        public override void HandleError(string msg)
        {
            _result = MessageType.Error + msg;
        }

        public override void HandleSuccess(string msg)
        {
            _result = MessageType.Success + msg;
        }

        public override void HandleSpawnWorkers(int count)
        {
            _result = MessageType.SpawnWorkers + count.ToString(CultureInfo.InvariantCulture);
        }

        public override void HandleSpawnAllWorkers()
        {
            _result = MessageType.SpawnAllWorkers.ToString();
        }

        public override void HandleStopWorkers(int count)
        {
            _result = MessageType.StopWorkers + count.ToString(CultureInfo.InvariantCulture);
        }

        public override void HandleStopAllWorkers()
        {
            _result = MessageType.StopAllWorkers.ToString();
        }

        public override void HandleWorkersMemory()
        {
            _result = MessageType.WorkersMemory.ToString();
        }

        public override void HandleWorkersLoad()
        {
            _result = MessageType.WorkersLoad.ToString();
        }

        public override void HandleWorkersCount()
        {
            _result = MessageType.WorkersCount.ToString();
        }

        public override void HandleRedisIp(string ip)
        {
            _result = MessageType.RedisIp + ip;
        }

        public override void HandleTotalLoad()
        {
            _result = MessageType.TotalLoad.ToString();
        }

        public override void HandleTotalMemory()
        {
            _result = MessageType.TotalMemory.ToString();
        }

        public override void HandleLoadStatus()
        {
            _result = MessageType.LoadStatus.ToString();
        }

        public override void HandleSetLoadStatus(LoadStatus status)
        {
            _result = MessageType.SetLoadStatus.ToString() + status.ToString();
        }

        public override void HandleCurrentWorkerLimit()
        {
            _result = MessageType.CurrentWorkerLimit.ToString();
        }

        public override void HandleMaximumWorkerLimit()
        {
            _result = MessageType.MaximumWorkerLimit.ToString();
        }

        public override void HandleLibrariesList()
        {
            _result = MessageType.LibrariesList.ToString();
        }

        public override void HandleHasLibrary(string libraryName)
        {
            _result = MessageType.HasLibrary.ToString() + libraryName;
        }

        public override void HandleInstallLibrary(string libraryName)
        {
            _result = MessageType.InstallLibrary.ToString() + libraryName;
        }

        public void SendMessage(ClusterMessage msg)
        {
            HandleMessage(msg);
        }

        public void BeginSendMessage(ClusterMessage msg)
        {
            HandleMessage(msg);
        }

        public override void HandleUnknownMessage()
        {
            throw new NotImplementedException();
        }
    }
}
