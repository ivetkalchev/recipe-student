using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using data_access;

namespace recipe_web.Pages
{
    public class RegisterModel : PageModel
    {

        public RegisterModel()
        {
            Username = "";
            Email = "";
            Password = "";
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
