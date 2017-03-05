using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using System.Text;
using Entities;
using FreeFilesServerConsole.EF;

namespace FreeFilesServerConsole.Repository
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

        public Guid Login(string userName, string password)
        {
            var userList = this.GetAllUsers();
            var user = userList.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            return user != null ? user.UserID : Guid.Empty;
            
        }
        public List<EF.User> GetAllUsers()
        {
            var userList = from users in _freeFilesObjectContext.Users

                           select new { users };
            List<FreeFilesServerConsole.EF.User> List = new List<EF.User>();
            foreach (var item in userList)
            {
                EF.User user = new EF.User();
                user.UserName = item.users.UserName;
                user.UserID = item.users.UserID;
                user.Password = item.users.Password;
                user.IsEnabled = item.users.IsEnabled;
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
            _freeFilesObjectContext.Users.Attach(efUser);
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
    }
}
