using db_helpers;
using entity_classes;
using exceptions;

namespace manager_classes
{
    public class UserManager : IUserManager
    {
        private readonly IDBUserHelper userHelper;

        public UserManager(IDBUserHelper userHelper)
        {
            this.userHelper = userHelper ?? throw new ArgumentNullException(nameof(userHelper));
        }

        public bool RegisterDesktopUser(DesktopUser newUser)
        {
            if (IsDesktopUserTaken(newUser))
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
                newUser.GetBirthdate()
            );

            userHelper.InsertDesktopUser(newUser);
            return true;
        }

        public bool RegisterWebUser(WebUser newUser)
        {
            if (IsWebUserTaken(newUser))
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

            userHelper.InsertWebUser(newUser);
            return true;
        }

        private bool IsDesktopUserTaken(DesktopUser newUser)
        {
            if (IsUsernameTaken(newUser.GetUsername()))
            {
                throw new AlreadyExistUserException("Username");
            }
            if (IsEmailTaken(newUser.GetEmail()))
            {
                throw new AlreadyExistUserException("Email");
            }
            if (IsBsnTaken(newUser.GetBsn()))
            {
                throw new AlreadyExistUserException("BSN");
            }
            return false;
        }

        private bool IsWebUserTaken(WebUser newUser)
        {
            if (IsUsernameTaken(newUser.GetUsername()))
            {
                throw new AlreadyExistUserException("Username");
            }
            if (IsEmailTaken(newUser.GetEmail()))
            {
                throw new AlreadyExistUserException("Email");
            }
            return false;
        }

        private string CapitalizeFirstLetter(string text)
        {
            return char.ToUpper(text[0]) + text.Substring(1).ToLower();
        }

        public DesktopUser LoginDesktopUser(string username, string password)
        {
            return userHelper.GetDesktopUser(username, Hasher.HashText(password));
        }

        public WebUser LoginWebUser(string username, string password)
        {
            return userHelper.GetWebUser(username, Hasher.HashText(password));
        }

        public bool IsUsernameTaken(string username)
        {
            return userHelper.IsUsernameTaken(username);
        }

        public bool IsEmailTaken(string email)
        {
            return userHelper.IsEmailTaken(email);
        }

        public bool IsBsnTaken(int bsn)
        {
            return userHelper.IsBSNTaken(bsn);
        }

        public void UpdateDesktopUserDetails(DesktopUser user, string newFirstName, string newLastName, string newEmail, DateTime newBirthdate, Gender newGender, int newBsn)
        {
            if (newEmail != user.GetEmail() && IsEmailTakenByOtherUser(user, newEmail))
            {
                throw new AlreadyExistUserException("email");
            }

            if (newBsn != user.GetBsn() && IsBsnTakenByOtherUser(user, newBsn))
            {
                throw new AlreadyExistUserException("BSN");
            }

            userHelper.UpdateDesktopUserDetails(user, CapitalizeFirstLetter(newFirstName), CapitalizeFirstLetter(newLastName), newEmail, newBirthdate, newGender, newBsn);
        }

        public WebUser GetWebUserByUsername(string username)
        {
            return userHelper.GetWebUserByUsername(username);
        }

        public void UpdateWebUserDetails(WebUser user, string newCaption, string newEmail)
        {
            userHelper.UpdateWebUserDetails(user, newCaption, newEmail);
        }

        private bool IsEmailTakenByOtherUser(DesktopUser user, string email)
        {
            return userHelper.IsEmailTakenByOtherUser(user, email);
        }

        private bool IsBsnTakenByOtherUser(DesktopUser user, int bsn)
        {
            return userHelper.IsBsnTakenByOtherUser(user, bsn);
        }

        public List<DesktopUser> GetAllDesktopUsers()
        {
            return userHelper.GetAllDesktopUsers();
        }

        //not used currently
        public List<WebUser> GetAllWebUsers()
        {
            return userHelper.GetAllWebUsers();
        }

        public void DeleteUser(DesktopUser user)
        {
            userHelper.DeleteUser(user);
        }

        //not used currently
        public void DeleteWebUser(WebUser user)
        {
            userHelper.DeleteWebUser(user);
        }

        public void PromoteUserToAdmin(DesktopUser user)
        {
            userHelper.PromoteUserToAdmin(user);
        }

        public List<Gender> GetAllGenders()
        {
            return userHelper.GetAllGenders();
        }

        public Gender GetGenderByName(string genderName)
        {
            var genders = userHelper.GetAllGenders();
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
