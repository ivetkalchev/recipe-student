﻿using DTOs;

namespace DAOs
{
    public interface IUserDAO
    {
        void CreateUser(DesktopUserDTO user);
        string GetUserRole(string username);
        bool IsBsnTaken(int bsn);
        bool IsEmailTaken(string email);
        bool IsUsernameTaken(string username);
        bool ValidateUserCredentials(string username, string password);
    }
}