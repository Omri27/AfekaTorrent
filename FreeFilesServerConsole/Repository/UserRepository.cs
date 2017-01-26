using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public void AddUser(User user)
        {
            _freeFilesObjectContext.Users.AddObject(user);
        }
    }
}
