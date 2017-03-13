using DownloadManager.Abstract;

namespace DownloadManager
{
    public static  class FileProviderServerManager
    {
        static IFileProviderServer FileProviderServer;
        public static void StartFileProviderServer()
        {
           FileProviderServer= Factory.Instance.CreateFileProviderServer();
           FileProviderServer.SetupFileServer();
        }
    }
}
