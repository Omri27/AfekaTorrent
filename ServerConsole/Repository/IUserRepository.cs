using System;
using System.Collections.Generic;
using Entities;

namespace ServerConsole.Repository
{
    public interface IUserRepository
    {
        void AddUser(EF.User user);
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
