using exceptions;
using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;

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

        public DesktopUser(int idUser, string username, string email, string password,
            Role role, string firstName, string lastName, int bsn, Gender gender, DateTime birthdate)
            : base(idUser, username, email, password)
        {
            Role = role;
            FirstName = firstName;
            LastName = lastName;
            Bsn = bsn;
            Gender = gender;
            Birthdate = birthdate;
        }

        public Role Role
        {
            get { return role; }
            private set { role = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullUserException(nameof(FirstName));

                if (Regex.IsMatch(firstName, @"^[a-zA-Z]+$"))
                    throw new InvalidNameException("First Name");

                FirstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullUserException(nameof(LastName));

                if (Regex.IsMatch(firstName, @"^[a-zA-Z]+$"))
                    throw new InvalidNameException("Last Name");

                LastName = value;
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