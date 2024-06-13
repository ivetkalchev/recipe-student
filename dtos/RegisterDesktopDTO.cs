using exceptions;
using entity_classes;
using System.Text.RegularExpressions;

namespace dtos
{
    public class RegisterDesktopDTO
    {
        private string username;
        private string email;
        private string password;
        private string firstName;
        private string lastName;
        private int bsn;
        private Gender gender;
        private DateTime birthdate;

        public RegisterDesktopDTO(string username, string email, string password, string firstName, string lastName, int bsn, Gender gender, DateTime birthdate)
        {
            Username = username;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Bsn = bsn;
            Gender = gender;
            Birthdate = birthdate;
        }

        public string Username
        {
            get { return username; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullUserException(nameof(Username));

                username = value;
            }
        }

        public string Email
        {
            get { return email; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullUserException("Email");

                if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    throw new InvalidEmailException();

                email = value;
            }
        }

        public string Password
        {
            get { return password; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullUserException(nameof(Password));

                if (value.Length < 8 || !Regex.IsMatch(value, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$"))
                    throw new InvalidPasswordFormatException();

                password = value;
            }
        }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullUserException(nameof(FirstName));

                if (!Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                    throw new InvalidNameException("First Name");

                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullUserException(nameof(LastName));

                if (!Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                    throw new InvalidNameException("Last Name");

                lastName = value;
            }
        }

        public int Bsn
        {
            get { return bsn; }
            private set
            {
                if (value == 0)
                    throw new NullUserException(nameof(Bsn));

                var bsnString = value.ToString();

                if (bsnString.Length < 8 || bsnString.Length > 9)
                    throw new InvalidBsnLengthException();

                if (!Regex.IsMatch(bsnString, @"^\d+$"))
                    throw new InvalidBsnFormatException();

                bsn = value;
            }
        }


        public Gender Gender
        {
            get { return gender; }
            private set
            {
                if (value == null)
                    throw new NullUserException(nameof(Gender));

                gender = value;
            }
        }

        public DateTime Birthdate
        {
            get { return birthdate; }
            private set
            {
                DateTime today = DateTime.Now;
                int age = today.Year - value.Year;
                if (value > today.AddYears(-age)) age--;

                if (age < 14)
                    throw new InvalidBirthdateException();

                birthdate = value;
            }
        }
    }
}
