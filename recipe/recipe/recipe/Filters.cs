using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipe
{
    public class Filters
    {
        public MealType MealTypeFilter { get; set; }
        public Budget BudgetFilter { get; set; }
        public TimeRequired TimeRequiredFilter { get; set; }
        public Difficulty DifficultyFilter { get; set; }
        public DietaryRestriction DietaryRestrictionFilter { get; set; }
    }
}
