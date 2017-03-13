using System;
using System.Collections.Generic;
using System.Linq;
using ServerConsole.EF;

namespace ServerConsole.Repository
{
    class UserRepository : IUserRepository
    {
        private FreeFilesEntitiesContext _freeFilesObjectContext;
        public UserRepository(IUnitOfWork unitOfWork)
        {

            _freeFilesObjectContext = unitOfWork as FreeFilesEntitiesContext;
        }
        public void AddUser(EF.User user)
        {
            _freeFilesObjectContext.Users.AddObject(user);
        }

        public  EF.User Login(string userName, string password)
        {
            Guid userId = Guid.NewGuid();
            var userList = this.GetAllUsers();
            EF.User efUser = userList.FirstOrDefault(x => x.UserName.Equals(userName) && x.Password.Equals(password));
            if (efUser != null && !efUser.IsActive && efUser.IsEnabled)
            {
                efUser.IsActive = true;
                _freeFilesObjectContext.Users.ApplyCurrentValues(efUser);
                _freeFilesObjectContext.SaveChanges();
            }
         
            return efUser;

        }

        public void Logout(Guid userId)
        {
            EF.User efUser = _freeFilesObjectContext.Users.Where(o => o.UserID == userId).FirstOrDefault();
            efUser.IsActive = false;
            _freeFilesObjectContext.Users.ApplyCurrentValues(efUser);
            _freeFilesObjectContext.SaveChanges();
        }
        public List<EF.User> GetAllUsers()
        {
            var userList = from users in _freeFilesObjectContext.Users

                           select new { users };
            List<EF.User> List = new List<EF.User>();
            foreach (var item in userList)
            {
                EF.User user = new EF.User();
                user.UserName = item.users.UserName;
                user.UserID = item.users.UserID;
                user.Password = item.users.Password;
                user.IsActive = item.users.IsActive;
                user.IsEnabled = item.users.IsEnabled;
                user.SharedFolder = item.users.SharedFolder;
                user.DownloadFolder = item.users.DownloadFolder;
                user.Roles = item.users.Roles;
                List.Add(user);
            }
            return List;
        }

        public void DeleteUser(Guid UserID)
        {
            EF.User user = _freeFilesObjectContext.Users.Where(o => o.UserID == UserID).FirstOrDefault();
            _freeFilesObjectContext.Users.DeleteObject(user);
            _freeFilesObjectContext.SaveChanges();
        }

        public EF.User GetUser(Guid UserID)
        {
            return  _freeFilesObjectContext.Users.Where(o => o.UserID == UserID).FirstOrDefault();
        }

        public void EditUser(Entities.User user)
        {
            EF.User efUser = _freeFilesObjectContext.Users.Where(o => o.UserID == user.UserID).FirstOrDefault();
            efUser.UserName = user.UserName;
            efUser.Password = user.Password;
            efUser.IsEnabled = user.IsEnabled;
            _freeFilesObjectContext.Users.ApplyCurrentValues(efUser);
            _freeFilesObjectContext.SaveChanges();
        }

        public int GetUsersCount()
        {
            return _freeFilesObjectContext.Users.Count();
        }

        public void UpdateFolders(string download, string shared,Guid UserId)
        {
            EF.User efUser = _freeFilesObjectContext.Users.Where(o => o.UserID == UserId).FirstOrDefault();
            efUser.SharedFolder = shared;
            efUser.DownloadFolder = download;
            _freeFilesObjectContext.Users.Attach(efUser);
            _freeFilesObjectContext.SaveChanges();

        }

        public int GetActiveUsersCount()
        {
            return _freeFilesObjectContext.Users.Where(x  => x.IsActive).Count();
        }
    }
}
