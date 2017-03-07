using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FreeFile.DownloadManager;

namespace FreeFiles.TransferEngine.WCFPNRP
{
     static class FileReader
    {
        
        internal static byte[] GetFileBytes(string fileName, string hash, long partNumber)
        {
            var file=FileUtility.FindFileByHash(Config.SharedFolder, fileName, hash);
            return FileUtility.ReadFilePart(file, partNumber,0, 0);                        
        }

        internal static byte[] GetFileBytes(string fileName, long partNumber,long partCount, long mod)
        {
            return FileUtility.ReadFilePart(fileName, partNumber, partCount,  mod);
        }

    }
}
