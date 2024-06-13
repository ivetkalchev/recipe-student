using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using manager_classes;
using dtos;
using Microsoft.AspNetCore.Authorization;

namespace recipe_web.Pages
{
    [Authorize] 
    public class EditProfileModel : PageModel
    {
        private IUserManager userManager;

        [BindProperty]
        public WebUserDTO WebUserDTO { get; set; }

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

            WebUserDTO = new WebUserDTO
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
                userManager.UpdateWebUserDetails(existingUser, WebUserDTO.Caption, WebUserDTO.Email);
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
