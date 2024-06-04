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

        public bool RegisterDesktopUser(DesktopUser newUser)
        {
            if (IsUserTaken(newUser) || !IsValidUser(newUser))
            {
                return false;
            }

            newUser = new DesktopUser(
                newUser.GetIdUser(),
                newUser.GetUsername(),
                newUser.GetEmail(),
                Hasher.HashText(newUser.GetPassword()),
                newUser.GetRole(),
                CapitalizeFirstLetter(newUser.GetFirstName()),
                CapitalizeFirstLetter(newUser.GetLastName()),
                newUser.GetBsn(),
                newUser.GetGender(),
                newUser.GetBirthdate(),
                CapitalizeFirstLetter(Hasher.HashText(newUser.GetSecurityAnswer()))
            );

            dbHelper.InsertDesktopUser(newUser);
            return true;
        }

        private bool IsValidUser(DesktopUser newUser)
        {
            return IsPasswordValid(newUser.GetPassword()) &&
                   IsEmailValid(newUser.GetEmail()) &&
                   IsBsnValid(newUser.GetBsn()) &&
                   IsNameValid(newUser.GetFirstName(), "first name") &&
                   IsNameValid(newUser.GetLastName(), "last name") &&
                   IsBirthdateValid(newUser.GetBirthdate());
        }

        private bool IsUserTaken(DesktopUser newUser)
        {
            if (IsUsernameTaken(newUser.GetUsername()))
            {
                throw new AlreadyExistUserException("username");
            }
            if (IsEmailTaken(newUser.GetEmail()))
            {
                throw new AlreadyExistUserException("email");
            }
            if (IsBSNTaken(newUser.GetBsn()))
            {
                throw new AlreadyExistUserException("BSN");
            }
            return false;
        }

        private bool IsBsnValid(int bsn)
        {
            string bsnString = bsn.ToString();
            if (bsnString.Length < 8 || bsnString.Length > 9)
            {
                throw new InvalidBsnLengthException();
            }
            //only numbers
            if (!Regex.IsMatch(bsnString, @"^\d+$"))
            {
                throw new InvalidBsnFormatException();
            }
            return true;
        }

        private bool IsNameValid(string name, string nameType)
        {
            //only l
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                throw new InvalidNameException(nameType);
            }
            return true;
        }

        private bool IsBirthdateValid(DateTime birthdate)
        {
            int age = DateTime.Now.Year - birthdate.Year;
            if (birthdate > DateTime.Now.AddYears(-age)) age--;
            if (age < 14)
            {
                throw new InvalidBirthdateException();
            }
            return true;
        }

        public bool IsPasswordValid(string password)
        {
            if (password.Length < 8)
            {
                throw new InvalidPasswordLengthException();
            }
            //one lowercase and uppercase letter, number and special symbol
            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!""#$%&'()*+,-./:;<=>?@[\\\]^_`{|}~])[A-Za-z\d!""#$%&'()*+,-./:;<=>?@[\\\]^_`{|}~]+$"))
            {
                throw new InvalidPasswordFormatException();
            }

            return true;
        }

        private bool IsEmailValid(string email)
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

        public List<Gender> GetAllGenders()
        {
            return dbHelper.GetAllGenders();
        }

        public Gender GetGenderByName(string genderName)
        {
            var genders = dbHelper.GetAllGenders();
            foreach (var gender in genders)
            {
                if (gender.GetName().Equals(genderName, StringComparison.OrdinalIgnoreCase))
                {
                    return gender;
                }
            }
            return null;
        }
    }
}
