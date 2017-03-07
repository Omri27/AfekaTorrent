using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeFilesServerConsole.EF.Repository
{
    class FileRepository:IFilesRepository
    {
        private FreeFilesEntitiesContext _freeFilesObjectContext;
        public FileRepository(IUnitOfWork unitOfWork)
        {
            
            _freeFilesObjectContext = unitOfWork as FreeFilesEntitiesContext;
        }
        public List<FreeFilesServerConsole.EF.File> SearchAvaiableFiles(string fileName)
        {

            if (fileName.Equals("*"))
            {
                var allfilesList = from files in _freeFilesObjectContext.Files
                                   join users in _freeFilesObjectContext.Users on files.UserID equals users.UserID
                                   join peers in _freeFilesObjectContext.Peers on files.PeerID equals peers.PeerID
                                   
                                   //where files.FileName.Contains(fileName)
                                   where users.IsActive == true
                                   select new { files, peers,users };
                List<FreeFilesServerConsole.EF.File> List = new List<File>();
                foreach (var item in allfilesList)
                {
                    File file = new File();
                    file.FileName = item.files.FileName;
                    file.FileSize = item.files.FileSize;
                    file.FileType = item.files.FileType;
                    file.UserID = item.files.UserID;
                    file.PeerHostName = item.peers.PeerHostName;
                    file.PeerID = item.peers.PeerID;
                    List.Add(file);
                }
                return List;
            }
            else
            {
                var filesList = from files in _freeFilesObjectContext.Files
                                join peers in _freeFilesObjectContext.Peers on files.PeerID equals peers.PeerID
                                join users in _freeFilesObjectContext.Users on files.UserID equals users.UserID
                                where files.FileName.Contains(fileName) && users.IsActive == true
                                select new { files, peers, users };
                List<FreeFilesServerConsole.EF.File> List = new List<File>();
                foreach (var item in filesList)
                {
                    File file = new File();
                    file.FileName = item.files.FileName;
                    file.FileSize = item.files.FileSize;
                    file.FileType = item.files.FileType;
                    file.UserID = item.files.UserID;
                    file.PeerHostName = item.peers.PeerHostName;
                    file.PeerID = item.peers.PeerID;
                    List.Add(file);
                }
                return List;
            }
           // return List;
        }

        public void AddFiles(List<FreeFilesServerConsole.EF.File> FilesList)
        {
            var files = GetAllFilesByHostName(FilesList.First().PeerHostName);
            //var files = GetAllFiles();

            //_freeFilesObjectContext = new FreeFilesEntitiesContext();
            try
            {
                foreach (FreeFilesServerConsole.EF.File file in FilesList)
                {
                    if(!files.Any(x=>x.FileName.Equals(file.FileName)))
                        _freeFilesObjectContext.Files.AddObject(file);
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.InnerException.Message);
            }
        }

        public void AddPeer(FreeFilesServerConsole.EF.Peer Peer)
        {
            //_freeFilesObjectContext = new FreeFilesEntitiesContext();
            try
            {
                _freeFilesObjectContext.Peers.AddObject(Peer);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.InnerException.Message);
            }
        }

        public void Save()
        {
            _freeFilesObjectContext.Save();            
        }

        public List<File> GetAllFiles()
        {
            var filesList = from files in _freeFilesObjectContext.Files
                            join peers in _freeFilesObjectContext.Peers on files.PeerID equals peers.PeerID
                            join users in _freeFilesObjectContext.Users on files.UserID equals users.UserID
                            //where files.FileName.Contains(fileName)
                            where users.IsActive == true
                            select new { files, peers,users };
            List<FreeFilesServerConsole.EF.File> List = new List<File>();
            foreach (var item in filesList)
            {
                File file = new File();
                file.FileName = item.files.FileName;
                file.FileSize = item.files.FileSize;
                file.FileType = item.files.FileType;
                file.UserID = item.files.UserID;
                file.PeerHostName = item.peers.PeerHostName;
                file.PeerID = item.peers.PeerID;
                List.Add(file);
            }
            return List;
        }
        public List<EF.File> GetAllFilesByHostName(string hostname)
        {
            var filesList = from files in _freeFilesObjectContext.Files 
                            join peers in _freeFilesObjectContext.Peers on files.PeerID equals peers.PeerID
                            join users in _freeFilesObjectContext.Users on files.UserID equals users.UserID
                            //where files.FileName.Contains(fileName)
                            where files.PeerHostName == hostname && users.IsActive == true
                            select new { files,users,peers };
            List<FreeFilesServerConsole.EF.File> List = new List<File>();
            foreach (var item in filesList)
            {
                File file = new File();
                file.FileName = item.files.FileName;
                file.FileSize = item.files.FileSize;
                file.FileType = item.files.FileType;
                file.PeerHostName = item.peers.PeerHostName;
                file.UserID = item.files.UserID;
                file.PeerID = item.files.PeerID;
                List.Add(file);
            }
            return List;
        }
    }
}
