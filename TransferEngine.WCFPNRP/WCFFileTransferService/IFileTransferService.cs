using System.ServiceModel;

namespace TransferEngine.WCFPNRP.WCFFileTransferService
{    
    [ServiceContract]
     interface IFileTransferService
    {
      
        [OperationContract(IsOneWay = false)]
        byte[] TransferFile(string fileName, long partNumber , long countPart , long mod);
    }
}
