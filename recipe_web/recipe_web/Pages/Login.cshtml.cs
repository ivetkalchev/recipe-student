using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using recipe_web.DTOs;
using manager_classes;
using System.Security.Claims;

namespace recipe_web.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginDTO LoginDTO { get; set; }

        private readonly IUserManager userManager;
        private readonly ILogger<LoginModel> logger;

        public LoginModel(IUserManager userManager, ILogger<LoginModel> logger)
        {
            this.userManager = userManager;
            this.logger = logger;
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

            logger.LogInformation("Attempting login for user: {Username}", LoginDTO.Username);

            string hashedPassword = Hasher.HashText(LoginDTO.Password);
            logger.LogInformation("Hashed password: {HashedPassword}", hashedPassword);

            var webUser = userManager.LoginWebUser(LoginDTO.Username, hashedPassword);

            if (webUser == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                logger.LogWarning("Login attempt failed for user: {Username}", LoginDTO.Username);
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, webUser.IdUser.ToString()),
                new Claim(ClaimTypes.Name, webUser.Username),
                new Claim(ClaimTypes.Email, webUser.Email),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {

            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            logger.LogInformation("User {Username} successfully logged in", LoginDTO.Username);

            return RedirectToPage("/Index");
        }
    }
}
