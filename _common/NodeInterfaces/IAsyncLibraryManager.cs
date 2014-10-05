namespace _common.NodeInterfaces
{
    /// <summary>
    /// Async interface for library managing
    /// </summary>
    interface IAsyncLibraryManager
    {
        void HasLibrary(string libraryName);
        void GetLibraryList();
        void InstallLibrary(string libraryName);
    }
}
