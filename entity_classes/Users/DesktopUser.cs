using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using entity_classes.Recipes;
using enum_classes.Users;

namespace entity_classes.Users
{
    public class DesktopUser : User
    {
        private Role role;
        private string firstName;
        private string lastName;
        private int bsn;
        private Gender gender;
        private DateTime birthdate;
        private SecurityQuestion securityQuestion;
        private string securityAnswer;
        private bool isActive;
        private List<Recipe> uploadedRecipes;
        public DesktopUser(int idUser, string username, string email, string password, 
            Role role, string firstName, string lastName, int bsn, Gender gender, DateTime birthdate, 
            SecurityQuestion securityQuestion, string securityAnswer, bool isActive, List<Recipe> uploadedRecipes) 
            : base(idUser, username, email, password)
        {
            this.role = role;
            this.firstName = firstName;
            this.lastName = lastName;
            this.bsn = bsn;
            this.gender = gender;
            this.birthdate = birthdate;
            this.securityQuestion = securityQuestion;
            this.securityAnswer = securityAnswer;
            this.isActive = isActive;
            this.uploadedRecipes = uploadedRecipes;
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

        public SecurityQuestion GetSecurityQuestion()
        {
            return securityQuestion;
        }

        public string GetSecurityAnswer()
        {
            return securityAnswer;
        }

        public string GetActivity()
        {
            return isActive ? "Active" : "Inactive";
        }

        public List<Recipe> GetUploadedRecipes()
        {
            return uploadedRecipes;
        }
    }
}

