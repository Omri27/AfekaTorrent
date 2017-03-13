using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeFilesServerConsole.Repository
{
    public interface IUserRepository
    {
        void AddUser(FreeFilesServerConsole.EF.User user);
        List<EF.User> GetAllUsers();

        void DeleteUser(Guid UserID);

        EF.User GetUser(Guid UserID);

        void EditUser(User user);

        int GetUsersCount();

        int GetActiveUsersCount();

         EF.User Login(string userName, string password);

        void UpdateFolders(string download, string shared, Guid UserId);

        void Logout(Guid userId);
    }
}
