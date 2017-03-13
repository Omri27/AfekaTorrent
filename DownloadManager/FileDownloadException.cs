using System;

namespace DownloadManager
{
    public sealed class FileDownloadException : Exception
    {
        public long PartNumber { get; private set; }
        public string FileName { get; private set; }
        public string Host { get; private set; }
        public FileDownloadException(long partNumber, string FileName, string Host, Exception innerException = null)
            : base("Download Failed!", innerException)
        {
            this.PartNumber = PartNumber;
            this.FileName = FileName;
            this.Host = Host;
        }
    }
}
