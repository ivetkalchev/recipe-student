using DBHelpers;
using entity_classes;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace manager_classes
{
    public class UserManager
    {
        private List<User> users = new List<User>();
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

            if (IsEmailTaken(desktopUser.GetEmail()) || IsBSNTaken(desktopUser.GetBsn()) || IsUsernameTaken(desktopUser.GetUsername()))
            {
                return false;
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

            users.Add(desktopUser);

            dbHelper.InsertDesktopUser(desktopUser);

            return true;
        }

        private bool IsValidUser(DesktopUser user)
        {
            return IsValidBsn(user.GetBsn()) &&
                   IsValidName(user.GetFirstName()) &&
                   IsValidName(user.GetLastName()) &&
                   IsValidBirthdate(user.GetBirthdate()) &&
                   IsValidPassword(user.GetPassword()) &&
                   IsValidEmail(user.GetEmail());
        }

        private bool IsValidBsn(int bsn)
        {
            return bsn.ToString().Length == 8 || bsn.ToString().Length == 9;
        }

        private bool IsValidName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }

        private bool IsValidBirthdate(DateTime birthdate)
        {
            int age = DateTime.Now.Year - birthdate.Year;
            if (birthdate > DateTime.Now.AddYears(-age)) age--;
            return age >= 14;
        }

        private bool IsValidPassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
        }

        private bool IsValidEmail(string email)
        {
            return email.Contains("@");
        }

        private string CapitalizeFirstLetter(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            return char.ToUpper(text[0]) + text.Substring(1).ToLower();
        }

        public DesktopUser LoginDesktopUser(string email, string password)
        {
            foreach (User user in users)
            {
                if (user.GetEmail().Equals(email) && user.GetPassword().Equals(Hasher.HashText(password)))
                {
                    return user as DesktopUser;
                }
            }

            return dbHelper.GetDesktopUser(email, Hasher.HashText(password));
        }

        public bool IsUsernameTaken(string username)
        {
            foreach (User user in users)
            {
                if (user.GetUsername().Equals(username))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsEmailTaken(string email)
        {
            foreach (User user in users)
            {
                if (user.GetEmail().Equals(email))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsBSNTaken(int bsn)
        {
            foreach (User user in users)
            {
                if (user is DesktopUser desktopUser && desktopUser.GetBsn() == bsn)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
