using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using recipe_web.DTOs;
using entity_classes;
using manager_classes;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace recipe_web.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginDTO LoginDTO { get; set; }

        private IUserManager userManager;

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
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToPage("/Index");
        }
    }
}
