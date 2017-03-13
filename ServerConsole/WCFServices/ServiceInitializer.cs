using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ServerConsole.WCFServices
{
    //[FileServiceAttributes(typeof(FilesService), ) ]
    
    public class ServiceInitializer : IServiceInitializer
    {
        private string _endPointAddress = string.Empty;
        private string _userEndPointAddress = string.Empty;
        public ServiceInitializer()
        {
            _endPointAddress = ConfigurationSettings.AppSettings["FileServiceEndPointAddress"].ToString();
            _userEndPointAddress = ConfigurationSettings.AppSettings["UserServiceEndPointAddress"].ToString();
        }
        public void InitializeServiceHost()
        {
        //    FileServiceAttributes serviceAttributes = FileServiceAttributes.FileServiceAttributeInit();
            Uri[] baseAddresses = new Uri[]{
                new Uri(_endPointAddress),
            };
            Uri[] userBaseAddresses = new Uri[]{
                new Uri(_userEndPointAddress),
            };
            
            ServiceHost Host = new ServiceHost(typeof(FilesService),baseAddresses);
            ServiceHost UserHost = new ServiceHost(typeof(UserService), userBaseAddresses);
            
            ServiceMetadataBehavior smb1 = new ServiceMetadataBehavior();
            ServiceMetadataBehavior smb2 = new ServiceMetadataBehavior();
            
            NetTcpBinding binding1 = new NetTcpBinding();
            //binding1.Security.Mode = SecurityMode.Message;
            binding1.Security.Mode=SecurityMode.None;
            binding1.Security.Transport.ClientCredentialType = TcpClientCredentialType.None;
           // binding1.Security.Transport.ProtectionLevel= ProtectionLevel.None;
           NetTcpBinding binding2 = new NetTcpBinding();
            // binding2.Security.Mode = SecurityMode.Message;
            binding2.Security.Mode = SecurityMode.None;
            binding2.Security.Transport.ClientCredentialType = TcpClientCredentialType.None;
           // binding2.Security.Transport.ProtectionLevel = ProtectionLevel.None;
            //smb1.HttpGetEnabled = true;
            //smb2.HttpGetEnabled = true;
            Host.Description.Behaviors.Add(smb1);
            UserHost.Description.Behaviors.Add(smb2);
            Host.AddServiceEndpoint(typeof(IMetadataExchange),
               MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
            UserHost.AddServiceEndpoint(typeof(IMetadataExchange),
               MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
            Host.AddServiceEndpoint(typeof(FilesService),
                binding1, "");
            UserHost.AddServiceEndpoint(typeof(UserService),
               binding2, "");
            
            
            
           
           
            Host.Open();
         
            UserHost.Open();
        }
    }

    
}
