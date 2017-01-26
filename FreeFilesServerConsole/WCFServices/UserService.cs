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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in both code and config file together.
    public class UserService : IUserService
    {
        private FreeFilesEntitiesContext _freeFilesObjectContext = new FreeFilesEntitiesContext();

        public void AddUser(User user)
        {
            UserRepository userRepository = new UserRepository(_freeFilesObjectContext as FreeFilesServerConsole.IUnitOfWork);
            userRepository.AddUser(user);
        }
    }
}
