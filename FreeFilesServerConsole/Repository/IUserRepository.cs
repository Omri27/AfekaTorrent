﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeFilesServerConsole.Repository
{
    public interface IUserRepository
    {
        void AddUser(EF.User user);
    }
}
