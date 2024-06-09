using entity_classes;
using manager_classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace recipe_web.Pages
{
    [Authorize]
    public class ToDoListModel : PageModel
    {
        private readonly IToDoListManager toDoManager;
        private readonly IRecipeManager recipeManager;

        public List<Recipe> ToDoList { get; set; }

        public ToDoListModel(IToDoListManager toDoManager, IRecipeManager recipeManager)
        {
            this.toDoManager = toDoManager;
            this.recipeManager = recipeManager;
        }

        public void OnGet()
        {
            var userIdClaim = GetUserClaimByType(ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                int userId = int.Parse(userIdClaim.Value);
                ToDoList = toDoManager.GetUserToDoList(userId);
            }
            else
            {
                ToDoList = new List<Recipe>();
            }
        }

        public IActionResult OnPostRemove(int id)
        {
            var userIdClaim = GetUserClaimByType(ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                int userId = int.Parse(userIdClaim.Value);
                toDoManager.RemoveFromToDoList(userId, id);
            }

            return RedirectToPage();
        }

        private Claim GetUserClaimByType(string claimType)
        {
            foreach (var claim in User.Claims)
            {
                if (claim.Type == claimType)
                {
                    return claim;
                }
            }
            return null;
        }
    }
}
