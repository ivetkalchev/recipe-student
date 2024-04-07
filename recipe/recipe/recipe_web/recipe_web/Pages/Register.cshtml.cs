using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using data_access;
using System.Threading.Tasks;
using logic_layer;

namespace recipe_web.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly DataRegisterWeb dbRegister;
        public RegisterModel()
        {
            string connectionString = "Data Source=mssqlstud.fhict.local;Initial Catalog=dbi526066_recipe;User ID=dbi526066_recipe;Password=123123;Encrypt=False";
            dbRegister = new DataRegisterWeb(connectionString);

            Username = "";
            Email = "";
            Password = "";
        }

        [BindProperty]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (dbRegister.DoesUsernameExist(Username))
            {
                ModelState.AddModelError(string.Empty, "Username already exists.");
                return Page();
            }

            if (dbRegister.DoesEmailExist(Email))
            {
                ModelState.AddModelError(string.Empty, "Email already exists.");
                return Page();
            }

            WebUser newUser = dbRegister.InsertUser(Username, Password, Email);

            return RedirectToPage("/Login");
        }

    }
}
