using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.Configuration;

namespace FreeFilesServerConsole.WCFServices
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

            Host.AddServiceEndpoint(typeof(FilesService),
                new BasicHttpBinding(), "");
            UserHost.AddServiceEndpoint(typeof(UserService),
                new BasicHttpBinding(), "");
            ServiceMetadataBehavior smb1 = new ServiceMetadataBehavior();
            ServiceMetadataBehavior smb2 = new ServiceMetadataBehavior();
            smb1.HttpGetEnabled = true;
            smb2.HttpGetEnabled = true;
            Host.Description.Behaviors.Add(smb1);
            Host.Open();
            UserHost.Description.Behaviors.Add(smb2);
            UserHost.Open();
        }
    }

    
}
