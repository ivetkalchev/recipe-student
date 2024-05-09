using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;
using manager_classes;

namespace recipe_web.Pages
{
    public class UserProfileModel : PageModel
    {
        private readonly UserManager userManager;
        public WebUserDTO UserDto { get; set; }
        public string Username { get; private set; }

        public UserProfileModel(UserManager userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult OnGet()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Login");
            }

            Username = User.Identity.Name;
            UserDto = userManager.GetWebUserByUsername(Username);

            if (UserDto != null)
            {
                return Page();
            }
            else
            {
                return NotFound("User not found.");
            }
        }
    }
}
