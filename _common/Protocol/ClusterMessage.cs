namespace _common.Protocol
{
    public enum MessageType
    {
        // Common commands
        Error,
        Success,

        // Worker managing
        SpawnWorkers,
        SpawnAllWorkers,
        StopWorkers,
        StopAllWorkers,
        WorkersMemory,
        WorkersLoad,
        WorkersCount,
        RedisIp,

        // System information
        TotalLoad,
        TotalMemory,

        // Load managing
        LoadStatus,
        SetLoadStatus,
        CurrentWorkerLimit,
        MaximumWorkerLimit,

        // Library managing
        LibrariesList,
        HasLibrary,
        InstallLibrary        
    };

    public struct ClusterMessage
    {
        public MessageType Type;
        public string Data;
    }
}
