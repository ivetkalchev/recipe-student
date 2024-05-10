using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using manager_classes;

namespace recipe_web.Pages
{
    public class EditProfileModel : PageModel
    {
        private readonly UserManager userManager;

        [BindProperty]
        public WebUserDTO UserDto { get; set; }

        [BindProperty]
        public ProfilePicDTO ProfilePic { get; set; }

        [BindProperty]
        public IFormFile FileUpload { get; set; }

        public EditProfileModel(UserManager userManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public IActionResult OnGet()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToPage("/Login");

            var username = User.Identity.Name;
            UserDto = userManager.GetWebUserByUsername(username);

            if (UserDto == null)
                return NotFound("User not found.");

            return Page();
        }
    }
}
