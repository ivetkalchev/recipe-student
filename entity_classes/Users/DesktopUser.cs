using exceptions;
using System.Text.RegularExpressions;

namespace entity_classes
{
    public class DesktopUser : User
    {
        private Role role;
        private string firstName;
        private string lastName;
        private int bsn;
        private Gender gender;
        private DateTime birthdate;

        public DesktopUser(int idUser, string username, string email, string password, Role role, string firstName, string lastName, int bsn, Gender gender, DateTime birthdate)
            : base(idUser, username, email, password)
        {
            this.role = role;
            this.firstName = firstName;
            this.lastName = lastName;
            this.bsn = bsn;
            this.gender = gender;
            this.birthdate = birthdate;
            ValidateDesktopUser();
        }

        public Role GetRole()
        {
            return role;
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public int GetBsn()
        {
            return bsn;
        }

        public Gender GetGender()
        {
            return gender;
        }

        public DateTime GetBirthdate()
        {
            return birthdate;
        }

        public void SetFirstName(string firstName)
        {
            if (!IsNameValid(firstName))
            {
                throw new InvalidNameException("first name");
            }
            this.firstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            if (!IsNameValid(lastName))
            {
                throw new InvalidNameException("last name");
            }
            this.lastName = lastName;
        }

        public void SetBsn(int bsn)
        {
            if (!IsBsnValid(bsn))
            {
                throw new InvalidBsnFormatException();
            }
            this.bsn = bsn;
        }

        public void SetBirthdate(DateTime birthdate)
        {
            if (!IsBirthdateValid(birthdate))
            {
                throw new InvalidBirthdateException();
            }
            this.birthdate = birthdate;
        }

        private bool IsNameValid(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }

        private bool IsBsnValid(int bsn)
        {
            string bsnString = bsn.ToString();
            return bsnString.Length >= 8 && bsnString.Length <= 9 && Regex.IsMatch(bsnString, @"^\d+$");
        }

        private bool IsBirthdateValid(DateTime birthdate)
        {
            int age = DateTime.Now.Year - birthdate.Year;
            if (birthdate > DateTime.Now.AddYears(-age)) age--;
            return age >= 14;
        }

        private void ValidateDesktopUser()
        {
            if (!IsUserValid() ||
                !IsBsnValid(bsn) ||
                !IsNameValid(firstName) ||
                !IsNameValid(lastName) ||
                !IsBirthdateValid(birthdate))
            {
                throw new InvalidUserException("Desktop user data is invalid");
            }
        }
        }
    }
}