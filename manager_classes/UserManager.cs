using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using exceptions;
using db_helpers;
using entity_classes;

namespace manager_classes
{
    public class UserManager : IUserManager
    {
        private IDBUserHelper dbHelper;

        public UserManager(IDBUserHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        public bool RegisterDesktopUser(DesktopUser desktopUser)
        {
            if (!IsValidUser(desktopUser))
            {
                return false;
            }

            if (IsEmailTaken(desktopUser.GetEmail()))
            {
                throw new AlreadyExistException("email");
            }

            if (IsUsernameTaken(desktopUser.GetUsername()))
            {
                throw new AlreadyExistException("username");
            }

            if (IsBSNTaken(desktopUser.GetBsn()))
            {
                throw new AlreadyExistException("BSN");
            }

            desktopUser = new DesktopUser(
                desktopUser.GetIdUser(),
                desktopUser.GetUsername(),
                desktopUser.GetEmail(),
                Hasher.HashText(desktopUser.GetPassword()),
                desktopUser.GetRole(),
                CapitalizeFirstLetter(desktopUser.GetFirstName()),
                CapitalizeFirstLetter(desktopUser.GetLastName()),
                desktopUser.GetBsn(),
                desktopUser.GetGender(),
                desktopUser.GetBirthdate(),
                CapitalizeFirstLetter(Hasher.HashText(desktopUser.GetSecurityAnswer()))
            );

            dbHelper.InsertDesktopUser(desktopUser);

            return true;
        }

        private bool IsValidUser(DesktopUser user)
        {
            return IsValidPassword(user.GetPassword()) &&
                   IsValidEmail(user.GetEmail()) &&
                   IsValidBsn(user.GetBsn()) &&
                   IsValidName(user.GetFirstName(), "first name") &&
                   IsValidName(user.GetLastName(), "last name") &&
                   IsValidBirthdate(user.GetBirthdate());
        }

        private bool IsValidBsn(int bsn)
        {
            string bsnString = bsn.ToString();
            if (bsnString.Length < 8 || bsnString.Length > 9)
            {
                throw new InvalidBsnLengthException();
            }
            if (!Regex.IsMatch(bsnString, @"^\d+$"))
            {
                throw new InvalidBsnFormatException();
            }
            return true;
        }

        private bool IsValidName(string name, string nameType)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                throw new InvalidNameException(nameType);
            }
            return true;
        }

        private bool IsValidBirthdate(DateTime birthdate)
        {
            int age = DateTime.Now.Year - birthdate.Year;
            if (birthdate > DateTime.Now.AddYears(-age)) age--;
            if (age < 14)
            {
                throw new InvalidBirthdateException();
            }
            return true;
        }

        public bool IsValidPassword(string password)
        {
            if (password.Length < 8)
            {
                throw new InvalidPasswordLengthException();
            }

            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!""#$%&'()*+,-./:;<=>?@[\\\]^_`{|}~])[A-Za-z\d!""#$%&'()*+,-./:;<=>?@[\\\]^_`{|}~]+$"))
            {
                throw new InvalidPasswordFormatException();
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            if (!email.Contains("@"))
            {
                throw new InvalidEmailException();
            }
            return true;
        }

        private string CapitalizeFirstLetter(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            return char.ToUpper(text[0]) + text.Substring(1).ToLower();
        }

        public DesktopUser LoginDesktopUser(string username, string password)
        {
            return dbHelper.GetDesktopUser(username, Hasher.HashText(password));
        }

        public bool IsUsernameTaken(string username)
        {
            return dbHelper.IsUsernameTaken(username);
        }

        public bool IsEmailTaken(string email)
        {
            return dbHelper.IsEmailTaken(email);
        }

        public bool IsBSNTaken(int bsn)
        {
            return dbHelper.IsBSNTaken(bsn);
        }

        public void UpdateUserDetails(DesktopUser user, string newLastName, string newEmail)
        {
            dbHelper.UpdateUserDetails(user, newLastName, newEmail);
        }

        public List<DesktopUser> GetAllDesktopUsers()
        {
            return dbHelper.GetAllDesktopUsers();
        }

        public void DeleteUser(DesktopUser user)
        {
            dbHelper.DeleteUser(user);
        }

        public void PromoteUserToAdmin(DesktopUser user)
        {
            dbHelper.PromoteUserToAdmin(user);
        }
    }
}
