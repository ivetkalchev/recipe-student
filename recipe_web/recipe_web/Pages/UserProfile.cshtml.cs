using Microsoft.AspNetCore.Mvc.RazorPages;
using manager_classes;
using recipe_web.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace recipe_web.Pages
{
    [Authorize]
    public class UserProfileModel : PageModel
    {
        private IUserManager userManager;

        public UserDTO UserDTO { get; set; }

        public UserProfileModel(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public void OnGet()
        {
            var username = User.Identity.Name;

            var webUser = userManager.GetWebUserByUsername(username);

            UserDTO = new UserDTO
            {
                Username = webUser.GetUsername(),
                Email = webUser.GetEmail(),
                Caption = webUser.GetCaption()
            };
        }
    }
}
