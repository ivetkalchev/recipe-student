using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using entity_classes;
using manager_classes;
using System.Linq;
using System.Security.Claims;

namespace recipe_web.Pages
{
    [Authorize]
    public class RecipeDetailsModel : PageModel
    {
        private IRecipeManager recipeManager;

        public Recipe Recipe { get; set; }
        public DietRestriction DietRestriction { get; set; }
        public Difficulty Difficulty { get; set; }
        public bool IsInToDoList { get; set; }

        public RecipeDetailsModel(IRecipeManager recipeManager)
        {
            this.recipeManager = recipeManager;
        }

        public IActionResult OnGet(int id)
        {
            Recipe = recipeManager.GetRecipeById(id);
            if (Recipe == null)
            {
                TempData["ErrorMessage"] = "Recipe not found.";
                return RedirectToPage("/ErrorPage");
            }

            DietRestriction = Recipe.GetDietRestriction();
            Difficulty = Recipe.GetDifficulty();

            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                TempData["ErrorMessage"] = "User ID claim not found.";
                return RedirectToPage("/ErrorPage");
            }

            int userId = int.Parse(userIdClaim.Value);
            IsInToDoList = recipeManager.IsRecipeInToDoList(userId, id);

            return Page();
        }

        public IActionResult OnPostAddToDoList(int id)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                TempData["ErrorMessage"] = "User ID claim not found.";
                return RedirectToPage("/ErrorPage");
            }

            int userId = int.Parse(userIdClaim.Value);
            recipeManager.AddToDoList(userId, id);
            return RedirectToPage(new { id = id });
        }
    }
}
