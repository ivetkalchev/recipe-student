using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
        private string securityAnswer;

        public DesktopUser(int idUser, string username, string email, string password,
            Role role, string firstName, string lastName, int bsn, Gender gender, DateTime birthdate,
            string securityAnswer)
            : base(idUser, username, email, password)
        {
            this.role = role;
            this.firstName = firstName;
            this.lastName = lastName;
            this.bsn = bsn;
            this.gender = gender;
            this.birthdate = birthdate;
            this.securityAnswer = securityAnswer;
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

        public string GetSecurityAnswer()
        {
            return securityAnswer;
        }
    }
}