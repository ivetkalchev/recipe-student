using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using entity_classes;
using manager_classes;
using System.Security.Claims;
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
            Reviews = reviewManager.GetReviewsByRecipeId(id) ?? new List<Review>();
        }

        public IActionResult OnPostAddToDoList(int id)
        {
            try
            {
                toDoManager.AddToDoList(GetUserId(), id);
                return RedirectToPage(new { id = id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to add recipe to To-Do List. Please try again later.");
                // Optionally log the error message
                return Page();
            }
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string validEmail = "user@example.com";
            WebUser user = new WebUser(GetUserId(), User.Identity.Name, validEmail, "ValidPassword1!", "Sample Caption");
            Recipe recipe = recipeManager.GetRecipeById(id);

            Review review = new Review(0, recipe, NewReview.RatingValue, NewReview.ReviewText);
            review.SetUser(user);

            reviewManager.AddReview(review);

            return RedirectToPage(new { id = id });
        }

        public IActionResult OnPostEditReview(int reviewId, int id)
        {
            Review review = reviewManager.GetReviewById(reviewId);
            if (review?.GetUser()?.GetIdUser() == GetUserId())
            {
                NewReview = new ReviewDTO
                {
                    RatingValue = review.GetRatingValue(),
                    ReviewText = review.GetReviewText()
                };
                reviewManager.DeleteReview(reviewId);
            }
            return RedirectToPage(new { id = id });
        }

        public IActionResult OnPostDeleteReview(int reviewId, int id)
        {
            Review review = reviewManager.GetReviewById(reviewId);
            if (review?.GetUser()?.GetIdUser() == GetUserId())
            {
                reviewManager.DeleteReview(reviewId);
            }
            return RedirectToPage(new { id = id });
        }

        public int GetUserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
