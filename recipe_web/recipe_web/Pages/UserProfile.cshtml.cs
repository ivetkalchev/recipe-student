using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using manager_classes;

namespace recipe_web.Pages
{
    public class UserProfileModel : PageModel
    {
        private readonly UserManager userManager;
        public string Username { get; private set; }

        public UserProfileModel(UserManager userManager)
        {
            this.userManager = userManager;
        }
    }
}
