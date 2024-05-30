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
        public IFormFile FileUpload { get; set; }

        public EditProfileModel(UserManager userManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public IActionResult OnGet()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToPage("/Login");

            return Page();
        }
    }
}
