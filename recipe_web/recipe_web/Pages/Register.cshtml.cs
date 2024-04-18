using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using data_access;

namespace recipe_web.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly DataRegisterWeb dbRegister;

        public RegisterModel()
        {
            string connectionString = "Data Source=mssqlstud.fhict.local;Initial Catalog=dbi526066_recipe;User ID=dbi526066_recipe;Password=123123;Encrypt=False";
            dbRegister = new DataRegisterWeb(connectionString);
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (dbRegister.DoesUsernameExist(Username))
            {
                return Page();
            }

            if (dbRegister.DoesEmailExist(Email))
            {
                return Page();
            }

           dbRegister.InsertUser(Username, Password, Email);

            return RedirectToPage("/Index");
        }
    }
}
