using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes.User
{
    public class CompanyUser : User
    {
        private string firstName;
        private string lastName;
        private int bsn;
        private Gender Gender;
        private DateTime birthdate;
        private int uploadedRecipes;
        public CompanyUser(int idUser, string role, string username, string email, string password, string firstName, 
            string lastName, int bsn, Gender gender, DateTime birthdate, int uploadedRecipes) 
            : base(idUser, role, username, email, password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.bsn = bsn;
            this.Gender = gender;
            this.birthdate = birthdate;
            this.uploadedRecipes = uploadedRecipes;
        }
    }
}

