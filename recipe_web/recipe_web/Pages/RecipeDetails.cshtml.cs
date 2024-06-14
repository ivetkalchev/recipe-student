using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using entity_classes;
using manager_classes;
using System.Security.Claims;
using recipe_web.DTOs;
using System.Collections.Generic;

namespace recipe_web.Pages
{
    [Authorize]
    public class RecipeDetailsModel : PageModel
    {
        private readonly IRecipeManager recipeManager;
        private readonly IToDoListManager toDoManager;
        private readonly IReviewManager reviewManager;

        [BindProperty]
        public ReviewDTO NewReview { get; set; }
        public int? EditingReviewId { get; set; }
        public List<Review> Reviews { get; set; }
        public Recipe Recipe { get; set; }
        public bool IsInToDoList { get; set; }

        public RecipeDetailsModel(IRecipeManager recipeManager, IToDoListManager toDoManager, IReviewManager reviewManager)
        {
            this.recipeManager = recipeManager;
            this.toDoManager = toDoManager;
            this.reviewManager = reviewManager;
            NewReview = new ReviewDTO();
        }

        public IActionResult OnGet(int id, int? editingReviewId)
        {
            Recipe = recipeManager.GetRecipeById(id);

            if (Recipe == null)
            {
                return RedirectToPage("/ErrorPage", new { errorMessage = "The requested recipe does not exist." });
            }

            IsInToDoList = toDoManager.IsRecipeInToDoList(GetUserId(), id);
            Reviews = reviewManager.GetReviewsByRecipeId(id);
            EditingReviewId = editingReviewId;

            if (EditingReviewId.HasValue)
            {
                var review = reviewManager.GetReviewById(EditingReviewId.Value);
                if (review != null && review.GetUser().GetIdUser() == GetUserId())
                {
                    NewReview.RatingValue = review.GetRatingValue();
                    NewReview.ReviewText = review.GetReviewText();
                }
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var email = GetEmail();
            var password = GetPassword();
            var caption = GetCaption();

            var user = new WebUser(GetUserId(), User.Identity.Name, email, password, caption);
            var recipe = recipeManager.GetRecipeById(id);

            var review = new Review(0, recipe, NewReview.RatingValue, NewReview.ReviewText);
            review.SetUser(user);

            reviewManager.AddReview(review);

            return RedirectToPage(new { id = id });
        }

        public IActionResult OnPostAddToDoList(int id)
        {
            try
            {
                toDoManager.AddToDoList(GetUserId(), id);
                return RedirectToPage(new { id = id });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to add recipe to To-Do List. Please try again later.");
                return Page();
            }
        }

        public IActionResult OnPostEditReview(int reviewId, int id)
        {
            var review = reviewManager.GetReviewById(reviewId);
            if (review.GetUser().GetIdUser() == GetUserId())
            {
                EditingReviewId = reviewId;
                NewReview = new ReviewDTO
                {
                    RatingValue = review.GetRatingValue(),
                    ReviewText = review.GetReviewText()
                };
            }
            return RedirectToPage(new { id = id, editingReviewId = EditingReviewId });
        }

        public IActionResult OnPostUpdateReview(int reviewId, int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage(new { id = id, editingReviewId = reviewId });
            }

            var review = reviewManager.GetReviewById(reviewId);
            if (review != null && review.GetUser().GetIdUser() == GetUserId())
            {
                reviewManager.UpdateReview(reviewId, NewReview.RatingValue, NewReview.ReviewText);
            }

            return RedirectToPage(new { id = id });
        }

        public IActionResult OnPostDeleteReview(int reviewId, int id)
        {
            var review = reviewManager.GetReviewById(reviewId);
            if (review.GetUser().GetIdUser() == GetUserId())
            {
                reviewManager.DeleteReview(reviewId);
            }
            return RedirectToPage(new { id = id });
        }

        public int GetUserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public string GetEmail()
        {
            return User.FindFirstValue(ClaimTypes.Email);
        }

        public string GetPassword()
        {
            return User.FindFirstValue("Password");
        }

        public string GetCaption()
        {
            return User.FindFirstValue("Caption");
        }
    }
}