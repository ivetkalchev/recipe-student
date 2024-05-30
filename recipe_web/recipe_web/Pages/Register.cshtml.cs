using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using manager_classes;
using Microsoft.AspNetCore.Identity;

namespace recipe_web.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager userManager;
        public RegisterModel(UserManager userManager)
        {
            this.userManager = userManager;
        }

        //using dtos instead of binding models
        [BindProperty]
        public string Username { get; set; } = "";

        [BindProperty]
        public string Email { get; set; } = "";

        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        //validirane
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

            return RedirectToPage("/Login");
        }
    }
}
