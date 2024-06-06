using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using manager_classes;
using recipe_web.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace recipe_web.Pages
{
    [Authorize] // with role
    public class EditProfileModel : PageModel
    {
        private IUserManager userManager;

        [BindProperty]
        public UserDTO UserDTO { get; set; }

        public EditProfileModel(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult OnGet()
        {
            var username = User.Identity.Name;

            if (string.IsNullOrEmpty(username))
            {
                return RedirectToPage("/Login");
            }

            var webUser = userManager.GetWebUserByUsername(username);

            if (webUser == null)
            {
                return NotFound("User not found.");
            }

            UserDTO = new UserDTO
            {
                Username = webUser.GetUsername(),
                Email = webUser.GetEmail(),
                Caption = webUser.GetCaption()
            };

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var username = User.Identity.Name;
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToPage("/Login");
            }

            var existingUser = userManager.GetWebUserByUsername(username);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            try
            {
                userManager.UpdateWebUserDetails(existingUser, UserDTO.Caption, UserDTO.Email);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error updating user details: {ex.Message}");
                return Page();
            }

            return RedirectToPage("/UserProfile");
        }
    }
}
