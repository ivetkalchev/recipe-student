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

        private void ValidateName(string name, string nameType)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new NullUserException(nameType);
            }
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                throw new InvalidNameException(nameType);
            }
        }

        private void ValidateBsn(int bsn)
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
        }

        private void ValidateBirthdate(DateTime birthdate)
        {
            int age = DateTime.Now.Year - birthdate.Year;
            if (birthdate > DateTime.Now.AddYears(-age)) age--;
            if (age < 14)
            {
                throw new InvalidBirthdateException();
            }
        }

        public void DesktopUserValidation()
        {
             ValidateName(firstName, "first name");
             ValidateName(lastName, "last name");
             ValidateBsn(bsn);
             ValidateBirthdate(birthdate);
        }
    }
}