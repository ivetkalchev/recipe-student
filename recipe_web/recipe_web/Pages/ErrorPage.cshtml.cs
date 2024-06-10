using Microsoft.AspNetCore.Mvc.RazorPages;

namespace recipe_web.Pages
{
    public class ErrorPageModel : PageModel
    {
        public string ErrorMessage { get; set; }

        public void OnGet(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
