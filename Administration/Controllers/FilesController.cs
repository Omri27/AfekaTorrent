using FreeFile.DownloadManager.FileServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Administration.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Files()
        {
            FilesServiceClient fsc = new FilesServiceClient();
            List<Entities.File> fileList = new List<Entities.File>();
            List<File> fileModel = new List<File>();
            foreach (Entities.File file in fsc.GetAllFiles())
            {
                Entities.File currentFile = new Entities.File();
                currentFile.FileName = file.FileName;
                currentFile.FileSize = file.FileSize;
                currentFile.FileType = file.FileType;
                currentFile.PeerID = file.PeerID;
                currentFile.PeerHostName = file.PeerHostName;
                fileList.Add(currentFile);
            }
          
            return View(fileList);
        }
    }
}