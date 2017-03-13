using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DownloadManager.Abstract
{
    public sealed class Factory
    {
        Factory()
        {

            Assembly transferEngineAssembly = Assembly.LoadFile(Path.GetDirectoryName( Application.ExecutablePath) + "\\TransferEngine.WCFPNRP.dll");            
            var tnaTypes = transferEngineAssembly.GetTypes();
            foreach (var item in tnaTypes)
            {
                if (item.GetInterface("ITransferEngineFactory") != null)
                {
                    ITransferEngineFactory ITransferEngineFactory = Activator.CreateInstance(item) as ITransferEngineFactory;
                    this.transferEngine = ITransferEngineFactory.CreateTransferEngine();
                    this.fileProviderServer = this.transferEngine as IFileProviderServer;
                    break;
                }
            }
            /* Create
             *searchEngine;             
            */
            
        }
        static readonly object sharedObject = new object();
        static Factory instance;
        public static Factory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (sharedObject)
                    {
                        if (instance == null)
                        {
                            instance = new Factory();
                        }
                    }
                }
                return instance;
            }
        }
        
        ITransferEngine transferEngine;
        IFileProviderServer fileProviderServer;
     
        public ITransferEngine CreateTransferEngine()
        {
            return transferEngine;
        }

        public IFileProviderServer CreateFileProviderServer()
        {
            return fileProviderServer;
        }
    }
}
