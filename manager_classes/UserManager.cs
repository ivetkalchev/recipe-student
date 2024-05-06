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
    public class UserManager
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
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public void CreateUser(DesktopUserDTO user)
        {
            try
            {
                if (userDAO != null)
                {
                    userDAO.CreateUser(user);
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

        public bool AuthenticateUser(string username, string password, out DesktopUserDTO user)
        {
            user = null;
            try
            {
                return userDAO.AuthenticateUser(username, password, out user);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred while authenticating user: " + ex.Message);
                return false;
            }
        }

        public DesktopUserDTO GetUserByUsername(string username)
        {
            try
            {
                return userDAO.GetUserByUsername(username);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred while retrieving user by username: " + ex.Message);
                throw;
            }
        }
    }
}
