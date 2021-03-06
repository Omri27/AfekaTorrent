﻿using System;
using System.Collections.Generic;
using System.ServiceModel;
using ServerConsole.EF;
using ServerConsole.Repository;

namespace ServerConsole.WCFServices
{
    [ServiceContract]
    public class FilesService : IFileService
    {
        private EntitiesContext _objectContext=new EntitiesContext();
        [OperationContract]
        public void AddFiles(List<Entities.File> FilesList,Entities.Peer peer)
        {
            FileRepository fileRepository = new FileRepository(_objectContext as IUnitOfWork);
            this.AddPeer(externalPeerToEFPeer(peer));
            fileRepository.AddFiles(externalFileToEFFile(FilesList));
            
            SaveFile();
        }
        [OperationContract]
        public void AddPeer(EF.Peer Peer)
        {
            FileRepository fileRepository = new FileRepository(_objectContext as IUnitOfWork);
            fileRepository.AddPeer(Peer);

        }
        [OperationContract]
        public List<Entities.File> SearchAvaiableFiles(string fileName, Guid userId)
        {
            FileRepository fileRepository = new FileRepository(_objectContext as IUnitOfWork);
            return internalFileToEntityFile(fileRepository.SearchAvaiableFiles(fileName,userId));
        }
        [OperationContract]
        public List<Entities.File> GetAllFiles()
        {
            FileRepository fileRepository = new FileRepository(_objectContext as IUnitOfWork);
            return internalFileToEntityFile(fileRepository.GetAllFiles());
        }



        public void SaveFile()
        {
            _objectContext.Save();
        }

        private EF.Peer externalPeerToEFPeer(Entities.Peer peer)
        {
            EF.Peer EFPeer=new EF.Peer();
            EFPeer.PeerHostName = peer.PeerHostName;
            EFPeer.Comments = peer.Comments;
            EFPeer.PeerID = peer.PeerID;
            return EFPeer;
        }

        private List<EF.File> externalFileToEFFile(List<Entities.File> fileList)
        {
            List<EF.File> nativeFileTypeList = new List<EF.File>();
            foreach (var file in fileList)
            {
                EF.File EFFile = new EF.File();
                EFFile.FileID = Guid.NewGuid();
                EFFile.FileName = file.FileName;
                EFFile.FileSize = file.FileSize;
                EFFile.FileType = file.FileType;
                EFFile.PeerID = file.PeerID;
                EFFile.PeerHostName = file.PeerHostName;
                EFFile.UserID = file.UserID;
                nativeFileTypeList.Add(EFFile);
            }
            return nativeFileTypeList;
        }

        private List<Entities.File> internalFileToEntityFile(List<EF.File> fileList)
        {
            List<Entities.File> entityFileTypeList = new List<Entities.File>();
            foreach (var file in fileList)
            {
                Entities.File File = new Entities.File();
                File.FileName = file.FileName;
                File.FileSize = file.FileSize;
                File.FileType = file.FileType;
                File.PeerHostName = file.PeerHostName;
                File.PeerID = file.PeerID;
                File.UserID = file.UserID;
                entityFileTypeList.Add(File);
            }
            return entityFileTypeList;
        }

    }
}
