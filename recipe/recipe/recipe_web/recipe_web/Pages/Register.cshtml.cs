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
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (await dbRegister.DoesUsernameExistAsync(Username))
            {
                ModelState.AddModelError(string.Empty, "Username already exists.");
                return Page();
            }

            if (await dbRegister.DoesEmailExistAsync(Email))
            {
                ModelState.AddModelError(string.Empty, "Email already exists.");
                return Page();
            }

            await dbRegister.InsertUserAsync(Username, Password, Email);

            return RedirectToPage("/Login");
        }
    }
}
