namespace DownloadManager.Abstract
{
    public interface ITransferEngine
    {        
        byte[] GetFile(string filename, long partNumber, string hostName, long partCount, long mod);
    }
}
