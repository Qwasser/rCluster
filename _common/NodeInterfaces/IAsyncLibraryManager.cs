namespace _common.NodeInterfaces
{
    /// <summary>
    /// Async interface for library managing
    /// </summary>
    public interface IAsyncLibraryManager
    {
        void HasLibrary(string libraryName);
        void GetLibraryList();
        void InstallLibrary(string libraryName);
    }
}
