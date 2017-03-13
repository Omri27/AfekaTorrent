namespace DownloadManager.Abstract
{
    namespace DownloadManager.Abstract
    {
        public interface IFileInfoServerManager
        {
            void RegisterSharedFileInfo(string localServerName, string fileName, string hash, long size);
            void RemoveSharedFile(string localServerName, string fileName, string hash);
        }
    }
}
