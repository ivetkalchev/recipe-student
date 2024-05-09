using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace recipe_web.Pages
{
    public class ChangePasswordModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "New password is required")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Confirmation of the new password is required")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }


            var updateResult = UpdatePasswordAsync(NewPassword);
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

        private bool UpdatePasswordAsync(string newPassword)
        {
            //implement the logic to update the password in the db
            return true;
        }
    }
}
