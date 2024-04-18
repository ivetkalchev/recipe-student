using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace recipe_web.Pages
{
    public class CookiesModel : PageModel
    {
        public IActionResult OnGet()
        {
            
            return Page();
        }

        public IActionResult OnPost(string acceptCookies, string declineCookies)
        {
            
            if (!string.IsNullOrEmpty(acceptCookies))
            {
                Response.Cookies.Append("example_cookie", "accepted", new Microsoft.AspNetCore.Http.CookieOptions
                {
                    Expires = System.DateTimeOffset.Now.AddDays(30)
                });

                return RedirectToPage("/Index"); 
            }
            else if (!string.IsNullOrEmpty(declineCookies))
            {
                return RedirectToPage("/CookieDeclined"); 
            }

            return Page();
        }
    }
}
