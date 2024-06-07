using Microsoft.AspNetCore.Mvc.RazorPages;

namespace recipe_web.Pages
{
    public class ErrorPageModel : PageModel
    {
        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            ErrorMessage = TempData["ErrorMessage"] as string;
        }
    }
}
