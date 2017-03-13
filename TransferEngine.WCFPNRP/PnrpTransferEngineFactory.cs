using DownloadManager;
using DownloadManager.Abstract;

namespace TransferEngine.WCFPNRP
{
    public sealed class PnrpTransferEngineFactory : ITransferEngineFactory
    {
        public ITransferEngine CreateTransferEngine()
        {
            return new PnrpTransferEngine(Config.LocalHostyName, Config.LocalPort
                );
        }        
    }
}
