using db_helpers;
using entity_classes;
using exceptions;

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
            if (IsDesktopUserTaken(newUser) || !newUser.IsDesktopUserValid())
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

        public bool RegisterWebUser(WebUser newUser)
        {
            if (IsWebUserTaken(newUser) || !newUser.IsUserValid() || string.IsNullOrEmpty(newUser.GetCaption()))
            {
                return false;
            }

            newUser = new WebUser(
                newUser.GetIdUser(),
                newUser.GetUsername(),
                newUser.GetEmail(),
                Hasher.HashText(newUser.GetPassword()),
                newUser.GetCaption()
            );

            dbHelper.InsertWebUser(newUser);
            return true;
        }

        private bool IsDesktopUserTaken(DesktopUser newUser)
        {
            if (IsUsernameTaken(newUser.GetUsername()))
            {
                throw new AlreadyExistUserException("username");
            }
            if (IsEmailTaken(newUser.GetEmail()))
            {
                throw new AlreadyExistUserException("email");
            }
            if (IsBsnTaken(newUser.GetBsn()))
            {
                throw new AlreadyExistUserException("Bsn");
            }
            return false;
        }

        private bool IsWebUserTaken(WebUser newUser)
        {
            if (IsUsernameTaken(newUser.GetUsername()))
            {
                throw new AlreadyExistUserException("username");
            }
            if (IsEmailTaken(newUser.GetEmail()))
            {
                throw new AlreadyExistUserException("email");
            }
            return false;
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

        public WebUser LoginWebUser(string username, string password)
        {
            return dbHelper.GetWebUser(username, Hasher.HashText(password));
        }

        public bool IsUsernameTaken(string username)
        {
            return dbHelper.IsUsernameTaken(username);
        }

        public bool IsEmailTaken(string email)
        {
            return dbHelper.IsEmailTaken(email);
        }

        public bool IsBsnTaken(int bsn)
        {
            return dbHelper.IsBSNTaken(bsn);
        }

        public void UpdateDesktopUserDetails(DesktopUser user, string newFirstName, string newLastName, string newEmail, DateTime newBirthdate, Gender newGender, int newBsn)
        {
            if (!user.IsDesktopUserValid())
            {
                throw new InvalidUserException("Invalid user details");
            }

            if (newEmail != user.GetEmail() && IsEmailTakenByOtherUser(user, newEmail))
            {
                throw new AlreadyExistUserException("email");
            }

            if (newBsn != user.GetBsn() && IsBsnTakenByOtherUser(user, newBsn))
            {
                throw new AlreadyExistUserException("Bsn");
            }

            dbHelper.UpdateDesktopUserDetails(user, newFirstName, newLastName, newEmail, newBirthdate, newGender, newBsn);
        }

        public WebUser GetWebUserByUsername(string username)
        {
            return dbHelper.GetWebUserByUsername(username);
        }

        public void UpdateWebUserDetails(WebUser user, string newCaption, string newEmail)
        {
            dbHelper.UpdateWebUserDetails(user, newCaption, newEmail);
        }

        private bool IsEmailTakenByOtherUser(DesktopUser user, string email)
        {
            return dbHelper.IsEmailTakenByOtherUser(user, email);
        }

        private bool IsBsnTakenByOtherUser(DesktopUser user, int bsn)
        {
            return dbHelper.IsBsnTakenByOtherUser(user, bsn);
        }

        public List<DesktopUser> GetAllDesktopUsers()
        {
            return dbHelper.GetAllDesktopUsers();
        }

        public List<WebUser> GetAllWebUsers()
        {
            return dbHelper.GetAllWebUsers();
        }

        public void DeleteUser(DesktopUser user)
        {
            dbHelper.DeleteUser(user);
        }

        public void DeleteWebUser(WebUser user)
        {
            dbHelper.DeleteWebUser(user);
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