using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer
{
    public class CompanyUser : User
    {
        private string firstName;
        private string lastName;
        private int bsn;
        private string gender;
        private DateTime birthdate;
        public CompanyUser(string username, string password, string email,
                   string firstName, string lastName, int bsn, string gender, DateTime birthdate, int id = -1)
        : base(id, username, password, email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.bsn = bsn;
            this.gender = gender;
            this.birthdate = birthdate;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public int Bsn
        {
            get { return bsn; }
            set { bsn = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }
        public string ViewAnalytics(List<Recipe> allRecipes, List<Recipe> approvedRecipes, List<Recipe> deniedRecipes)
        {
            int totalRecipes = allRecipes.Count;
            int totalApproved = approvedRecipes.Count;
            int totalDenied = deniedRecipes.Count;

            return $"Total number of recipes: {totalRecipes}\n" +
                   $"Number of approved recipes: {totalApproved}\n" +
                   $"Number of denied recipes: {totalDenied}";
        }
    }
}

