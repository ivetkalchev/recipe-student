using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using DAOs;
using DTOs;
using entity_classes.Users;

namespace manager_classes
{
    public class UserManager : IUserManager
    {
        private IUserDAO userDAO;
        public UserManager(IUserDAO userDAO)
        {
            this.userDAO = userDAO;
        }
        public bool IsUsernameTaken(string username)
        {
            return userDAO.IsUsernameTaken(username);
        }
        public bool IsEmailTaken(string email)
        {
            return userDAO.IsEmailTaken(email);
        }
        public bool IsBsnTaken(int bsn)
        {
            return userDAO.IsBsnTaken(bsn);
        }
        public void CreateDesktopUser(DesktopUserDTO user)
        {
            try
            {
                if (userDAO != null)
                {
                    userDAO.CreateDesktopUser(user);
                }
                else
                {
                    throw new InvalidOperationException("UserDAO is not initialized.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred while creating user: " + ex.Message);
            }
        }
        public bool ValidateUserCredentials(string username, string password)
        {
            return userDAO.ValidateUserCredentials(username, password);
        }
        public bool ValidateSecurityAnswer(string username, string securityAnswer)
        {
            return userDAO.ValidateSecurityAnswer(username, securityAnswer);
        }
        public bool UpdatePassword(string username, string newPassword)
        {
            return userDAO.UpdatePassword(username, newPassword);
        }
        public void CreateWebUser(WebUserDTO user)
        {
            try
            {
                if (userDAO != null)
                {
                    userDAO.CreateWebUser(user);
                }
                else
                {
                    throw new InvalidOperationException("UserDAO is not initialized.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred while creating web user: " + ex.Message);
            }
        }
    }
}
