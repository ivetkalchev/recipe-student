using db_helpers;
using entity_classes;
using manager_classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using recipe_web.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace recipe_web.Pages
{
    public class RecipeDetailsModel : PageModel
    {
        private readonly IRecipeManager recipeManager;

        public Recipe Recipe { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>(); // Ensure Reviews is initialized
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
            Reviews = recipeManager.GetReviewsByRecipeId(id);
            IsInToDoList = recipeManager.IsRecipeInToDoList(GetUserId(), id);
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
                var user = new WebUser(GetUserId(), GetUsername(), GetUserEmail(), "", ""); // Fill in appropriate values
                var recipe = recipeManager.GetRecipeById(id);
                var newReview = new Review(0, recipe, Review.RatingValue, Review.ReviewText);
                newReview.SetUser(user);
                recipeManager.AddReview(newReview, user.GetIdUser());
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
                recipeManager.AddToDoList(GetUserId(), id);
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
