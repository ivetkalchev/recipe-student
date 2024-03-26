using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipe
{
    public class Admin : Users
    {
        private int bsn;
        private string? gender;
        private DateTime birthdate;

        public Admin(Users user, string username, string password, string email, string firstName, string lastName)
        : base(0, username, password, email, firstName, lastName)
        {
            Bsn = bsn;
            Gender = gender;
            Birthdate = birthdate;
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
        public void ViewAnalytics(List<Recipe> allRecipes, List<Recipe> approvedRecipes, List<Recipe> deniedRecipes)
        {
            int totalRecipes = allRecipes.Count;

            int totalApproved = approvedRecipes.Count;

            int totalDenied = deniedRecipes.Count;

            string message = $"Total number of recipes: {totalRecipes}\n" +
                             $"Number of approved recipes: {totalApproved}\n" +
                             $"Number of denied recipes: {totalDenied}";

            MessageBox.Show(message, "Recipe Analytics", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
