using System;

namespace DownloadManager
{
    public sealed class DataContainerEventArg<T>:EventArgs
    {
        public DataContainerEventArg(T data) : base() { this.Data = data; }
        public T Data { get; set; }
    }
}
