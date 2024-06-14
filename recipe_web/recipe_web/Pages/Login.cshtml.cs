using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using recipe_web.DTOs;
using manager_classes;
using System.Security.Claims;
using exceptions;

namespace recipe_web.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginDTO LoginDTO { get; set; }

        private readonly IUserManager userManager;

        public LoginModel(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var webUser = userManager.LoginWebUser(LoginDTO.Username, LoginDTO.Password);

                if (webUser == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, webUser.GetIdUser().ToString()),
                    new Claim(ClaimTypes.Name, webUser.GetUsername()),
                    new Claim(ClaimTypes.Email, webUser.GetEmail()),
                    new Claim("Password", webUser.GetPassword()),
                    new Claim("Caption", webUser.GetCaption())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            }
            catch (InvalidUserException)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
}
