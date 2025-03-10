using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using entity_classes;
using manager_classes;
using exceptions;
using recipe_web.DTOs;

namespace recipe_web.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterDTO RegisterDTO { get; set; }

        private readonly IUserManager userManager;

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
                ModelState.AddModelError("RegisterDTO.Username", "Username is already taken.");
                return Page();
            }

            if (userManager.IsEmailTaken(RegisterDTO.Email))
            {
                ModelState.AddModelError("RegisterDTO.Email", "Email is already taken.");
                return Page();
            }

            var newWebUser = new WebUser(
                idUser: 0,
                username: RegisterDTO.Username,
                email: RegisterDTO.Email,
                password: RegisterDTO.Password,
                caption: $"Hello, I am {RegisterDTO.Username}"
            );

            try
            {
                if (userManager.RegisterWebUser(newWebUser))
                {
                    return RedirectToPage("/Login");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
                    return Page();
                }
            }
            catch (InvalidUserException ex)
            {
                ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
                return Page();
            }
        }
    }
}
