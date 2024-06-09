using entity_classes;
using manager_classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using recipe_web.DTOs;
using System.Security.Claims;

namespace recipe_web.Pages
{
    public class RecipeDetailsModel : PageModel
    {
        private IRecipeManager recipeManager;
        private IReviewManager reviewManager;
        private IToDoListManager toDoManager;

        public Recipe Recipe { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public bool IsInToDoList { get; set; }

        [BindProperty]
        public ReviewDTO Review { get; set; }

        public RecipeDetailsModel(IRecipeManager recipeManager)
        {
            this.recipeManager = recipeManager;
        }

        public void OnGet(int id)
        {
            Recipe = recipeManager.GetRecipeById(id);
            Reviews = reviewManager.GetReviewsByRecipeId(id);
            IsInToDoList = toDoManager.IsRecipeInToDoList(GetUserId(), id);
        }

        public IActionResult OnPostAddReview(int id)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Please correct the form errors.";
                return Page();
            }

            try
            {
                var user = new WebUser(GetUserId(), GetUsername(), GetUserEmail(), "", ""); 
                var recipe = recipeManager.GetRecipeById(id);
                var newReview = new Review(0, recipe, Review.RatingValue, Review.ReviewText);
                newReview.SetUser(user);
                reviewManager.AddReview(newReview, user.GetIdUser());
                return RedirectToPage(new { id });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return Page();
            }
        }

        public IActionResult OnPostAddToDoList(int id)
        {
            try
            {
                toDoManager.AddToDoList(GetUserId(), id);
                return RedirectToPage(new { id });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return Page();
            }
        }

        private int GetUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userIdClaim != null ? int.Parse(userIdClaim) : 0;
        }

        private string GetUsername()
        {
            return User.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;
        }

        private string GetUserEmail()
        {
            return User.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;
        }
    }
}
