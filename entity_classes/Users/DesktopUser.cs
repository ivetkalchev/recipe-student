using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using enum_classes.Users;

namespace entity_classes.Users
{
    public class DesktopUser : User
    {
        private Role role;
        private string firstName;
        private string lastName;
        private int bsn;
        private Gender Gender;
        private DateTime birthdate;
        private SecurityQuestion securityQuestion;
        private string securityAnswer;
        private bool activity;
        private int uploadedRecipes;
        public DesktopUser(int idUser, string username, string email, string password, 
            Role role, string firstName, string lastName, int bsn, Gender gender, DateTime birthdate, 
            SecurityQuestion securityQuestion, string securityAnswer, bool activity, int uploadedRecipes) 
            : base(idUser, username, email, password)
        {
            this.role = role;
            this.firstName = firstName;
            this.lastName = lastName;
            this.bsn = bsn;
            this.Gender = gender;
            this.birthdate = birthdate;
            this.securityQuestion = securityQuestion;
            this.securityAnswer = securityAnswer;
            this.activity = activity;
            this.uploadedRecipes = uploadedRecipes;
        }
        public Role GetRole()
        {
            return role;
        }
    }
}

