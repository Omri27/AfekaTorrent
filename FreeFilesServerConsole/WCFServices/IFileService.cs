using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Entities;

namespace FreeFilesServerConsole.WCFServices
{
    public interface IFileService
    {
        void AddFiles(List<Entities.File> FilesList,Peer Peer);
        List<Entities.File> SearchAvaiableFiles(string fileName, Guid userId);
        List<Entities.File> GetAllFiles();
    }
}
