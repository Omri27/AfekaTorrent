﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Entities;
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
            user.UserID = Guid.NewGuid();
            UserRepository userRepository = new UserRepository(_freeFilesObjectContext as FreeFilesServerConsole.IUnitOfWork);

            userRepository.AddUser(externalUserToEFUser(user));

            SaveUser();
        }

        [OperationContract]

        public Guid Login(string userName, string password)
        {
            UserRepository userRepository = new UserRepository(_freeFilesObjectContext as FreeFilesServerConsole.IUnitOfWork);
            return userRepository.Login(userName, password);
        }

        [OperationContract]
        public List<Entities.User> GetAllUsers()
        {
            UserRepository userRepository = new UserRepository(_freeFilesObjectContext as FreeFilesServerConsole.IUnitOfWork);
            return internalUserToEntityUser(userRepository.GetAllUsers());
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
            EFUser.IsEnabled = user.IsEnabled;
            return EFUser;
        }

        private List<Entities.User> internalUserToEntityUser(List<FreeFilesServerConsole.EF.User> userList)
        {
            List<Entities.User> entityFileTypeList = new List<Entities.User>();
            foreach (var EFUser in userList)
            {
                Entities.User user = new Entities.User();
                user.UserName = EFUser.UserName;
                user.UserID = EFUser.UserID;
                user.Password = EFUser.Password;
                user.IsEnabled = EFUser.IsEnabled;
                user.SharedFolder = EFUser.SharedFolder;
                user.DownloadFolder = EFUser.DownloadFolder;
                entityFileTypeList.Add(user);
            }
            return entityFileTypeList;
        }

        private Entities.User internalSingleUserToEntityUser(EF.User EFUser)
        {
           
                Entities.User user = new Entities.User();
                user.UserName = EFUser.UserName;
                user.UserID = EFUser.UserID;
                user.Password = EFUser.Password;
                user.IsEnabled = EFUser.IsEnabled;
                user.SharedFolder = EFUser.SharedFolder;
                user.DownloadFolder = EFUser.DownloadFolder;
            return user;
        }

        [OperationContract]
        public void DeleteUser(Guid UserID)
        {
            UserRepository userRepository = new UserRepository(_freeFilesObjectContext as FreeFilesServerConsole.IUnitOfWork);
            userRepository.DeleteUser(UserID);
        }

        [OperationContract]
        public Entities.User GetUser(Guid UserID)
        {
            UserRepository userRepository = new UserRepository(_freeFilesObjectContext as FreeFilesServerConsole.IUnitOfWork);
            EF.User user =  userRepository.GetUser(UserID);
            return internalSingleUserToEntityUser(user);

        }
        [OperationContract]
        public void EditUser(Entities.User user)
        {
            UserRepository userRepository = new UserRepository(_freeFilesObjectContext as FreeFilesServerConsole.IUnitOfWork);
            userRepository.EditUser(user);
        }

        [OperationContract]
        public int GetUsersCount()
        {
            UserRepository userRepository = new UserRepository(_freeFilesObjectContext as FreeFilesServerConsole.IUnitOfWork);
            return  userRepository.GetUsersCount();
        }
        [OperationContract]
        public void UpdateFolders(string download, string shared, Guid UserId)
        {
            UserRepository userRepository = new UserRepository(_freeFilesObjectContext as FreeFilesServerConsole.IUnitOfWork);
            userRepository.UpdateFolders(download, shared, UserId);
        }
        [OperationContract]
        public void Logout(Guid userId)
        {
            UserRepository userRepository = new UserRepository(_freeFilesObjectContext as FreeFilesServerConsole.IUnitOfWork);
            userRepository.Logout(userId);
        }

        [OperationContract]
        public int GetActiveUsersCount()
        {
            UserRepository userRepository = new UserRepository(_freeFilesObjectContext as FreeFilesServerConsole.IUnitOfWork);
            return userRepository.GetActiveUsersCount();
        }
    }
}
