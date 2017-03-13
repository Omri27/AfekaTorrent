using DownloadManager;

namespace TransferEngine.WCFPNRP
{
     static class FileReader
    {
        
      
        internal static byte[] GetFileBytes(string fileName, long partNumber,long partCount, long mod)
        {
            return FileUtility.ReadFilePart(fileName, partNumber, partCount,  mod);
        }

    }
}
