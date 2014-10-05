using System.Collections.Generic;

namespace _common.Protocol
{
    public class ClusterResponseSender
    {
        private readonly IMessageSender _sender;

        public ClusterResponseSender(IMessageSender sender)
        {
            _sender = sender;
        }

        public void HandleError(string msg)
        {
            _sender.BeginSendMessage(MessageDataUtils.PackStringMessage(msg, MessageType.Error));
        }

        public void HandleSuccess(string msg)
        {
            _sender.BeginSendMessage(MessageDataUtils.PackStringMessage(msg, MessageType.Success));
        }

        public void HandleWorkersMemory(int memory)
        {
            _sender.BeginSendMessage(MessageDataUtils.PackIntMessage(memory, MessageType.WorkersMemory));
        }

        public void HandleWorkersLoad(int load)
        {
            _sender.BeginSendMessage(MessageDataUtils.PackIntMessage(load, MessageType.WorkersLoad));
        }
        public void HandleWorkersCount(int count)
        {
            _sender.BeginSendMessage(MessageDataUtils.PackIntMessage(count, MessageType.WorkersCount));
        }

        public void HandleRedisIp(string ip)
        {
            _sender.BeginSendMessage(MessageDataUtils.PackStringMessage(ip, MessageType.RedisIp));
        }


        public void HandleTotalLoad(int load)
        {
            _sender.BeginSendMessage(MessageDataUtils.PackIntMessage(load, MessageType.TotalLoad));
        }

        public void HandleTotalMemory(int memory)
        {
            _sender.BeginSendMessage(MessageDataUtils.PackIntMessage(memory, MessageType.TotalMemory));
        }

        public void HandleLoadStatus(LoadStatus status)
        {
            _sender.BeginSendMessage(MessageDataUtils.PackStringMessage(status.ToString(), MessageType.WorkersLoad));
        }

        public void HandleCurrentWorkerLimit(int limit)
        {
            _sender.BeginSendMessage(MessageDataUtils.PackIntMessage(limit, MessageType.CurrentWorkerLimit)); 
        }

        public void HandleMaximumWorkerLimit(int maxLimit)
        {
            _sender.BeginSendMessage(MessageDataUtils.PackIntMessage(maxLimit, MessageType.MaximumWorkerLimit));
        }

        public void HandleLibrariesList(List<string> libs)
        {
            _sender.BeginSendMessage(MessageDataUtils.PackListMessage(libs, MessageType.LibrariesList));
        }

        public void HandleHasLibrary(bool hasLibrary, string libraryName)
        {
            _sender.BeginSendMessage(MessageDataUtils.PackStringAndBool(libraryName, hasLibrary, MessageType.HasLibrary));
        }
    }
}
