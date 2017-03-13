using System;
using ServerConsole.WCFServices;

namespace ServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            #region tests
            //WCFServices.FilesService af = new WCFServices.FilesService();
            //EF.File ff = new EF.File();
            //ff.FileName = "111";
            //ff.FileSize = 2000;
            //ff.FileType = "pdf";
            //ff.PeerID = Guid.NewGuid();
            //List<EF.File> fileList = new List<EF.File>();
            //fileList.Add(ff);

            //Peer pp = new Peer();
            //pp.Comments = "www";
            //pp.PeerHostName = "ss.pnrp.net";
            //pp.PeerID = ff.PeerID;
            //List<EF.Peer> peerList = new List<EF.Peer>();
            //fileList.Add(ff);
            //af.AddFiles(fileList, pp);

            //af.SaveFile();
            //Console.ReadKey();
            #endregion
            ServiceInitializer si = new WCFServices.ServiceInitializer();
            si.InitializeServiceHost();
            Console.Write("started");
            Console.ReadKey();
        }
    }
}
