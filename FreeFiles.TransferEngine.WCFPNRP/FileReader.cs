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
        
      
        internal static byte[] GetFileBytes(string fileName, long partNumber,long partCount, long mod)
        {
            return FileUtility.ReadFilePart(fileName, partNumber, partCount,  mod);
        }

    }
}
