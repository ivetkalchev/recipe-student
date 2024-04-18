using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using data_access;
using System.ComponentModel.DataAnnotations;

namespace recipe_web.Pages
{
    public class LoginModel : PageModel
    {
        private string _connectionString = "Data Source=mssqlstud.fhict.local;Initial Catalog=dbi526066_recipe;User ID=dbi526066_recipe;Password=123123;Encrypt=False";

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public LoginModel()
        {
            Username = "";
            Password = "";
        }
        public IActionResult OnPost()
        {
            DataLogin dbLogin = new DataLogin(_connectionString);

            Username = Username?.Trim();
            Password = Password?.Trim();

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                return Page();
            }

            if (dbLogin.CheckLoginCredentials(Username, Password))
            {
                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
