using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace recipe_web.Pages
{
    [Authorize]
    public class ToDoListModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
