using System;
using System.Collections.Generic;

namespace ServerConsole.Repository
{
    public interface IFilesRepository
    {
        List<EF.File> SearchAvaiableFiles(string fileName, Guid userId);
        void AddFiles(List<EF.File> FilesList);
        List<EF.File> GetAllFiles();

        List<EF.File> GetAllFilesByHostName(string hostname);
    }
}
