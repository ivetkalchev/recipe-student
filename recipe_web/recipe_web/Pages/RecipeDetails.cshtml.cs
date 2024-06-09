using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using entity_classes;
using manager_classes;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using recipe_web.DTOs;

namespace recipe_web.Pages
{
    [Authorize]
    public class RecipeDetailsModel : PageModel
    {
        private IRecipeManager recipeManager;
        private IToDoListManager toDoManager;
        private IReviewManager reviewManager;

        [BindProperty]
        public ReviewDTO NewReview { get; set; }
        public Recipe Recipe { get; set; }
        public bool IsInToDoList { get; set; }
        public List<Review> Reviews { get; set; }

        public RecipeDetailsModel(IRecipeManager recipeManager, IToDoListManager toDoManager, IReviewManager reviewManager)
        {
            this.recipeManager = recipeManager;
            this.toDoManager = toDoManager;
            this.reviewManager = reviewManager;
        }

        public void OnGet(int id)
        {
            Recipe = recipeManager.GetRecipeById(id);
            if (Recipe == null)
            {
                return;
            }

            IsInToDoList = toDoManager.IsRecipeInToDoList(GetUserId(), id);
            Reviews = reviewManager.GetReviewsByRecipeId(id);
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Use a valid email for testing purposes
            string validEmail = "user@example.com";
            WebUser user = new WebUser(GetUserId(), User.Identity.Name, validEmail, "ValidPassword1!", "Sample Caption");
            Recipe recipe = recipeManager.GetRecipeById(id);

            Review review = new Review(0, recipe, NewReview.RatingValue, NewReview.ReviewText);
            review.SetUser(user);

            reviewManager.AddReview(review);

            return RedirectToPage(new { id = id });
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
