using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeFilesServerConsole.EF.Repository
{
    public interface IFilesRepository
    {
        List<FreeFilesServerConsole.EF.File> SearchAvaiableFiles(string fileName, Guid userId);
        void AddFiles(List<FreeFilesServerConsole.EF.File> FilesList);
        List<FreeFilesServerConsole.EF.File> GetAllFiles();

        List<EF.File> GetAllFilesByHostName(string hostname);
    }
}
