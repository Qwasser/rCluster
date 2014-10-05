namespace _common.NodeInterfaces
{
    /// <summary>
    /// Async interface for system information retrival
    /// </summary>
    public interface IAsyncSystemInfo
    {
        void GetSystemMemory();
        void GetSystemLoad();
    }
}
