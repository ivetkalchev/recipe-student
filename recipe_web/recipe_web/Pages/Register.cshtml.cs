using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dtos;
using entity_classes;
using manager_classes;
using exceptions;

namespace recipe_web.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterWebDTO RegisterWebDTO { get; set; }

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

            if (userManager.IsUsernameTaken(RegisterWebDTO.Username))
            {
                ModelState.AddModelError("RegisterDTO.Username", "Username is already taken.");
                return Page();
            }

            if (userManager.IsEmailTaken(RegisterWebDTO.Email))
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
                if (!userManager.RegisterWebUser(newWebUser))
                {
                    ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
                    return Page();
                }
            }
            catch (InvalidUserException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }

            return RedirectToPage("/Login");
        }
    }
}