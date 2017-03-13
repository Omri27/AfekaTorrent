namespace DownloadManager.Abstract
{
    public  interface ITransferEngineFactory
    {
        ITransferEngine CreateTransferEngine();
    }
}
