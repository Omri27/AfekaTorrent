using FreeFile.DownloadManager.FileServer;
using FreeFile.DownloadManager.UserServer;
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
        public ActionResult Files(string SearchString)
        {
            
            
            FilesServiceClient fsc = new FilesServiceClient();
            UserServiceClient usc = new UserServiceClient();

            ViewBag.UsersCount = usc.GetUsersCount();
            ViewBag.ActiveUsersCount = usc.GetActiveUsersCount();
            List<Entities.File> fileList = new List<Entities.File>();

            Entities.File[] files = fsc.GetAllFiles();

            ViewBag.FilesCount = files.Count();



            if (SearchString==null || SearchString.Equals(""))
            {
                //foreach (Entities.File file in files)
                //{
                //    Entities.File currentFile = new Entities.File();
                //    currentFile.FileName = file.FileName;
                //    currentFile.FileSize = file.FileSize;
                //    currentFile.FileType = file.FileType;
                //    currentFile.PeerID = file.PeerID;
                //    currentFile.PeerHostName = file.PeerHostName;
                //    fileList.Add(currentFile);
                //}
                //ViewBag.FileList = fileList;

                return View(files.ToList());
            }
           
            else
            {
                 fileList = files.ToList().Where(x=>x.FileName.ToLower().Contains(SearchString.ToLower())).ToList();
                return View(fileList);
            }
        }
    }
}