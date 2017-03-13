using System;
using System.Collections.Generic;
using Entities;

namespace ServerConsole.WCFServices
{
    public interface IUserService
    {
        void AddUser(Entities.User user);

        Entities.User Login(string userName, string password);

        List<Entities.User> GetAllUsers();

        void DeleteUser(Guid UserID);

         User  GetUser(Guid UserID);
        void EditUser(Entities.User user);

        int GetUsersCount();

        int GetActiveUsersCount();

        void UpdateFolders(string download, string shared, Guid UserId);

        void Logout(Guid userId);

        
    }
}
