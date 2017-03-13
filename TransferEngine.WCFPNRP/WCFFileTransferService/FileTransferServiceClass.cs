using System.ServiceModel;

namespace TransferEngine.WCFPNRP.WCFFileTransferService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single, UseSynchronizationContext = false)]
     class FileTransferServiceClass :IFileTransferService
    {
        public byte[] TransferFile(string fileName, long partNumber, long partCount , long mod)
        {
            return FileReader.GetFileBytes(fileName, partNumber, partCount, mod);
        }
    }
}