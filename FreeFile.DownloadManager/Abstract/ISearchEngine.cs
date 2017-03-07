﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeFile.DownloadManager.Abstract
{
    public interface ISearchEngine
    {
        List<Entities.File> Search(string searchPattern, Guid userId);
        List<FileSearchResult> SearchByFileHashCode(string hashCode);
    }
}
