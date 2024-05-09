using entity_classes.Users;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using manager_classes;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using DAOs;

namespace recipe_web.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserManager userManager;

        public LoginModel(UserManager userManager)
        {
            this.userManager = userManager;
        }

        [BindProperty]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Index");
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!userManager.UserExists(Username))
            {
                ModelState.AddModelError("Username", "The user does not exist.");
                return Page();
            }

            string hashedPassword = PasswordHasher.HashPassword(Password);

            if (!userManager.ValidateUserCredentials(Username, hashedPassword))
            {
                ModelState.AddModelError("Password", "Wrong credentials.");
                return Page();
            }

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, Username)
    };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            return RedirectToPage("/Index");
        }

    }
}