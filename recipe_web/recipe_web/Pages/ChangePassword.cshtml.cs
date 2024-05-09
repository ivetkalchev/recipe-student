using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using manager_classes;
using DAOs;

namespace recipe_web.Pages
{
    public class ChangePasswordModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "New password is required")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Confirmation of the new password is required")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        private readonly UserManager userManager;

        public ChangePasswordModel(UserManager userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!userManager.UserExists(Username))
            {
                ModelState.AddModelError("Username", "The specified user does not exist.");
                return Page();
            }

            string hashedNewPassword = PasswordHasher.HashPassword(NewPassword);

            var updateResult = userManager.UpdatePassword(Username, hashedNewPassword);
            
            if (updateResult)
            {
                TempData["SuccessMessage"] = "Password changed successfully.";
                return RedirectToPage("/Login");
            }
            else
            {
                ModelState.AddModelError("", "An error occurred while changing the password.");
                return Page();
            }
        }
    }
}
