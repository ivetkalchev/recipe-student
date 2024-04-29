using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enum_classes
{
    public enum SecurityQuestion
    {
        [Description("What was the name of your first pet?")]
        FirstPetName,

        [Description("What is your favourite film?")]
        FavouriteFilm,

        [Description("How many siblings do you have?")]
        Siblings
    }
}
