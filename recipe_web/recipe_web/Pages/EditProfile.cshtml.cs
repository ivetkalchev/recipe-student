using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using manager_classes;
using recipe_web.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace recipe_web.Pages
{
    [Authorize]
    public class EditProfileModel : PageModel
    {
        private readonly IUserManager userManager;

        [BindProperty]
        public UserDTO UserDTO { get; set; }

        public EditProfileModel(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult OnGet()
        {
            var username = User.Identity.Name;
            var webUser = userManager.GetWebUserByUsername(username);

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
            var existingUser = userManager.GetWebUserByUsername(username);

            if (existingUser.GetEmail() != UserDTO.Email && userManager.IsEmailTakenByOtherUser(existingUser.GetIdUser(), UserDTO.Email))
            {
                ModelState.AddModelError("UserDTO.Email", "Email is already taken.");
                return Page();
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
