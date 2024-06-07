using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using entity_classes;
using manager_classes;

namespace recipe_web.Pages
{
    public class RecipeDetailsModel : PageModel
    {
        private IRecipeManager recipeManager;

        public Recipe Recipe { get; set; }
        public DietRestriction DietRestriction { get; set; }
        public Difficulty Difficulty { get; set; }

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
            return Page();
        }
    }
}
