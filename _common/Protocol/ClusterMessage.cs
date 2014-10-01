namespace _common.Protocol
{
    public enum MessageDirection
    {
        Request,
        Response
    };

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
        CurrentWorkerLimit,
        MaximumWorkerLimit,

        // Library managing
        LibrariesList,
        HasLibrary,
        InstallLibrary        
    };

    public struct ClusterMessage
    {
        public MessageDirection Direction;
        public MessageType Type;
        public string Data;
    }
}
