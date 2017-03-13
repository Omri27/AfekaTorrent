using System;
using System.Collections.Generic;
using Entities;

namespace ServerConsole.WCFServices
{
    public interface IFileService
    {
        void AddFiles(List<Entities.File> FilesList,Peer Peer);
        List<Entities.File> SearchAvaiableFiles(string fileName, Guid userId);
        List<Entities.File> GetAllFiles();
    }
}
