﻿namespace entity_classes.Recipes
{
    public class Drink : Recipe
    {
        private bool isAlcoholic;
        private bool containsCaffeine;
        private bool servedHot;
        private int pours;
        public Drink(int idRecipe, string title, string description, string instructions, DesktopUser user, DateTime publishDate, TimeSpan preparationTime, TimeSpan cookingTime,
            DietRestriction dietRestriction, Difficulty difficulty, bool isAlcoholic, bool containsCaffeine, bool servedHot, int pours)
            : base(idRecipe, title, description, instructions, user, publishDate, preparationTime, cookingTime, dietRestriction, difficulty)
        {
            this.isAlcoholic = isAlcoholic;
            this.containsCaffeine = containsCaffeine;
            this.servedHot = servedHot;
            this.pours = pours;
        }

        public bool GetIsAlcoholic()
        {
            return isAlcoholic;
        }

        public bool GetContainsCaffeine()
        {
            return containsCaffeine;
        }

        public bool GetServedHot()
        {
            return servedHot;
        }

        public int Getours()
        {
            return pours;
        }

        public override decimal CalculateTotalTime()
        {
            decimal totalTime = (decimal)GetPreparationTime().TotalMinutes;
            if (servedHot)
            {
                totalTime += 5; //for heating purposes
            }
            return totalTime;
        }
    }
}
