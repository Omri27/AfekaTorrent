using System;
using System.Collections.Generic;
using System.Linq;
using ServerConsole.EF;

namespace ServerConsole.Repository
{
    class UserRepository : IUserRepository
    {
        private EntitiesContext _objectContext;
        public UserRepository(IUnitOfWork unitOfWork)
        {

            _objectContext = unitOfWork as EntitiesContext;
        }
        public void AddUser(EF.User user)
        {
            _objectContext.Users.AddObject(user);
        }

        public  EF.User Login(string userName, string password)
        {
            Guid userId = Guid.NewGuid();
            var userList = this.GetAllUsers();
            EF.User efUser = userList.FirstOrDefault(x => x.UserName.Equals(userName) && x.Password.Equals(password));
            if (efUser != null && !efUser.IsActive && efUser.IsEnabled)
            {
                efUser.IsActive = true;
                _objectContext.Users.ApplyCurrentValues(efUser);
                _objectContext.SaveChanges();
            }
            else
            {
                efUser = null;
            }
         
            return efUser;

        }

        public void Logout(Guid userId)
        {
            EF.User efUser = _objectContext.Users.Where(o => o.UserID == userId).FirstOrDefault();
            efUser.IsActive = false;
            _objectContext.Users.ApplyCurrentValues(efUser);
            _objectContext.SaveChanges();
        }
        public List<EF.User> GetAllUsers()
        {
            var userList = from users in _objectContext.Users

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
            EF.User user = _objectContext.Users.Where(o => o.UserID == UserID).FirstOrDefault();
            _objectContext.Users.DeleteObject(user);
            _objectContext.SaveChanges();
        }

        public EF.User GetUser(Guid UserID)
        {
            return  _objectContext.Users.Where(o => o.UserID == UserID).FirstOrDefault();
        }

        public void EditUser(Entities.User user)
        {
            EF.User efUser = _objectContext.Users.Where(o => o.UserID == user.UserID).FirstOrDefault();
            efUser.UserName = user.UserName;
            efUser.Password = user.Password;
            efUser.IsEnabled = user.IsEnabled;
            _objectContext.Users.ApplyCurrentValues(efUser);
            _objectContext.SaveChanges();
        }

        public int GetUsersCount()
        {
            return _objectContext.Users.Count();
        }

        public void UpdateFolders(string download, string shared,Guid UserId)
        {
            EF.User efUser = _objectContext.Users.Where(o => o.UserID == UserId).FirstOrDefault();
            efUser.SharedFolder = shared;
            efUser.DownloadFolder = download;
            _objectContext.Users.Attach(efUser);
            _objectContext.SaveChanges();

        }

        public int GetActiveUsersCount()
        {
            return _objectContext.Users.Where(x  => x.IsActive).Count();
        }
    }
}
