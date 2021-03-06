﻿using System;
using System.Collections.Generic;
using System.Linq;
using ServerConsole.EF;

namespace ServerConsole.Repository
{
    class FileRepository:IFilesRepository
    {
        private EntitiesContext _objectContext;
        public FileRepository(IUnitOfWork unitOfWork)
        {
            
            _objectContext = unitOfWork as EntitiesContext;
        }
        public List<EF.File> SearchAvaiableFiles(string fileName, Guid userId)
        {

            if (fileName.Equals("*"))
            {
                var allfilesList = from files in _objectContext.Files
                                   join users in _objectContext.Users on files.UserID equals users.UserID
                                   join peers in _objectContext.Peers on files.PeerID equals peers.PeerID
                                   
                                   //where files.FileName.Contains(fileName)
                                   where users.IsActive == true && users.UserID != userId
                                   select new { files, peers,users };
                List<EF.File> List = new List<File>();
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
                var filesList = from files in _objectContext.Files
                                join peers in _objectContext.Peers on files.PeerID equals peers.PeerID
                                join users in _objectContext.Users on files.UserID equals users.UserID
                                where files.FileName.Contains(fileName) && users.IsActive == true && users.UserID != userId
                                select new { files, peers, users };
                List<EF.File> List = new List<File>();
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

        public void AddFiles(List<EF.File> FilesList)
        {
            var files = GetAllFilesByHostName(FilesList.First().PeerHostName);
            //var files = GetAllFiles();

            //_objectContext = new EntitiesContext();
            try
            {
                foreach (EF.File file in FilesList)
                {
                    if(!files.Any(x=>x.FileName.Equals(file.FileName)))
                        _objectContext.Files.AddObject(file);
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.InnerException.Message);
            }
        }

        public void AddPeer(EF.Peer Peer)
        {
            //_objectContext = new EntitiesContext();
            try
            {
                _objectContext.Peers.AddObject(Peer);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.InnerException.Message);
            }
        }

        public void Save()
        {
            _objectContext.Save();            
        }

        public List<File> GetAllFiles()
        {
            var filesList = from files in _objectContext.Files
                            join peers in _objectContext.Peers on files.PeerID equals peers.PeerID
                            join users in _objectContext.Users on files.UserID equals users.UserID
                            //where files.FileName.Contains(fileName)
                            where users.IsActive == true
                            select new { files, peers,users };
            List<EF.File> List = new List<File>();
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
            var filesList = from files in _objectContext.Files 
                            join peers in _objectContext.Peers on files.PeerID equals peers.PeerID
                            join users in _objectContext.Users on files.UserID equals users.UserID
                            //where files.FileName.Contains(fileName)
                            where files.PeerHostName == hostname && users.IsActive == true
                            select new { files,users,peers };
            List<EF.File> List = new List<File>();
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
