using Microsoft.AspNetCore.Mvc.RazorPages;
using manager_classes;
using Microsoft.AspNetCore.Authorization;
using dtos;

namespace recipe_web.Pages
{
    [Authorize]
    public class UserProfileModel : PageModel
    {
        private IUserManager userManager;

        public WebUserDTO WebUserDTO { get; set; }

        public UserProfileModel(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public void OnGet()
        {
            var username = User.Identity.Name;

            if (string.IsNullOrEmpty(username))
            {
                RedirectToPage("/Login");
            }

            var webUser = userManager.GetWebUserByUsername(username);

            if (webUser == null)
            {
                NotFound("User not found.");
            }

            WebUserDTO = new WebUserDTO
            {
                Username = webUser.GetUsername(),
                Email = webUser.GetEmail(),
                Caption = webUser.GetCaption()
            };
        }
    }
}
