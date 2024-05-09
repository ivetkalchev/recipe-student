using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using manager_classes;
using DTOs;
using Microsoft.AspNetCore.Identity;
using DAOs;

namespace recipe_web.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager userManager;
        public RegisterModel(UserManager userManager)
        {
            Username = "";
            Email = "";
            Password = "";
            
            this.userManager = userManager;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (userManager.IsUsernameTaken(Username))
            {
                ModelState.AddModelError("Username", "Username is already taken.");
                return Page();
            }

            if (userManager.IsEmailTaken(Email))
            {
                ModelState.AddModelError("Email", "Email is already in use.");
                return Page();
            }

            string hashedPassword = PasswordHasher.HashPassword(Password);

            var newUser = new WebUserDTO
            {
                Username = Username,
                Email = Email,
                Password = hashedPassword,
                Caption = "Caption not added yet"
            };

            try
            {
                userManager.CreateWebUser(newUser);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the account: " + ex.Message);
                return Page();
            }

            return RedirectToPage("/Login");
        }
    }
}
