using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeFilesServerConsole.WCFServices
{
    public interface IUserService
    {
        void AddUser(Entities.User user);


        List<Entities.User> GetAllUsers();

        void DeleteUser(Guid UserID);

        User GetUser(Guid UserID);
    }
}
