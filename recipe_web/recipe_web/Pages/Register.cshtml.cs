using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using recipe_web.DTOs;
using entity_classes;
using manager_classes;

namespace recipe_web.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterDTO RegisterDTO { get; set; }

        private IUserManager userManager;

        public RegisterModel(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (userManager.IsUsernameTaken(RegisterDTO.Username))
            {
                ModelState.AddModelError("Username", "Username is already taken.");
                return Page();
            }

            if (userManager.IsEmailTaken(RegisterDTO.Email))
            {
                ModelState.AddModelError("Email", "Email is already taken.");
                return Page();
            }

            var newWebUser = new WebUser(
                idUser: 0,
                username: RegisterDTO.Username,
                email: RegisterDTO.Email,
                password: Hasher.HashText(RegisterDTO.Password),
                caption: $"Hello, I am {RegisterDTO.Username}!"
            );

            if (!userManager.RegisterWebUser(newWebUser))
            {
                ModelState.AddModelError("", "Registration failed. Please try again.");
                return Page();
            }

            TempData["SuccessMessage"] = "Registration successful. You can now log in.";
            return RedirectToPage("/Login");
        }
    }
}
