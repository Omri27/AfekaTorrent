using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using FreeFilesServerConsole.EF;
using FreeFilesServerConsole.Repository;
namespace FreeFilesServerConsole.WCFServices
{
    [ServiceContract]
    public class UserService : IUserService
    {
        private FreeFilesEntitiesContext _freeFilesObjectContext = new FreeFilesEntitiesContext();

        [OperationContract]
        public void AddUser(Entities.User user)
        {
            UserRepository userRepository = new UserRepository(_freeFilesObjectContext as FreeFilesServerConsole.IUnitOfWork);

            userRepository.AddUser(externalUserToEFUser(user));

            SaveUser();
        }

        public void SaveUser()
        {
            _freeFilesObjectContext.Save();
        }

        private EF.User externalUserToEFUser(Entities.User user)
        {
            EF.User EFUser = new EF.User();
            EFUser.UserID = user.UserID;
            EFUser.Password = user.Password;
            EFUser.SharedFolder = user.SharedFolder;
            EFUser.DownloadFolder = user.DownloadFolder;
            EFUser.UserName = user.UserName;
            return EFUser;
        }
    }
}
