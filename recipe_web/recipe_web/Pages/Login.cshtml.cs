using entity_classes.Users;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace recipe_web.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {

            if (User.Identity.IsAuthenticated)
            {

                Response.Redirect("/Index");
            }


            Username = "";
            Password = "";
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (AuthenticateUser(Username, Password))
            {
                return RedirectToPage("/Index");
            }
            else
            {
                Message = "Invalid login attempt";
                return Page();
            }
        }

        private bool AuthenticateUser(string username, string password)
        {

            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
        }
    }
}