using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_classes
{
    public abstract class Recipe
    {
        private int idRecipe;
        private string title;
        private string description;
        private string instructions;
        private DesktopUser user;
        private DateTime publishDate;
        private TimeSpan preparationTime;
        private TimeSpan cookingTime;
        private DietRestriction dietRestriction;
        private Difficulty difficulty;

        public Recipe(int idRecipe, string title, string description, string instructions, DesktopUser user, DateTime publishDate, TimeSpan cookingTime,
            DietRestriction dietRestriction, Difficulty difficulty)
        {
            this.idRecipe = idRecipe;
            this.title = title;
            this.description = description;
            this.instructions = instructions;
            this.user = user;
            this.publishDate = publishDate;
            this.cookingTime = cookingTime;
            this.dietRestriction = dietRestriction;
            this.difficulty = difficulty;
        }

        public int GetIdRecipe()
        {
            return idRecipe;
        }

        public string GetTitle()
        {
            return title;
        }

        public string GetDescription()
        {
            return description;
        }

        public string GetInstructions()
        {
            return instructions;
        }

        public User GetUser()
        {
            return user;
        }

        public DateTime GetPublishDate()
        {
            return publishDate;
        }

        public TimeSpan GetCookingTime()
        {
            return cookingTime;
        }

        public DietRestriction GetDietRestriction()
        {
            return dietRestriction;
        }

        public Difficulty GetDifficulty()
        {
            return difficulty;
        }

        public abstract decimal CalculatePrice();
    }
}
