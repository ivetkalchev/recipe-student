﻿using exceptions;
using System.Xml.Linq;

namespace entity_classes
{
    public class Ingredient
    {
        private int idIngredient;
        private string nameIngredient;
        private TypeIngredient typeIngredient;

        public Ingredient(int idIngredient, string nameIngredient, TypeIngredient typeIngredient)
        {
            IdIngredient = idIngredient;
            NameIngredient = nameIngredient;
            TypeIngredient = typeIngredient;
        }

        public int IdIngredient
        {
            get { return idIngredient; }
            private set { idIngredient = value; }
        }

        public string NameIngredient
        {
            get { return nameIngredient; }
            private set
            {
                if (string.IsNullOrEmpty(nameIngredient))
                    throw new NullIngredientException("Name of Ingredient");

                if (!System.Text.RegularExpressions.Regex.IsMatch(nameIngredient, @"^[a-zA-Z\s]+$"))
                {
                    throw new InvalidIngredientNameException();
                }

                nameIngredient = value;
            }
        }

        public TypeIngredient TypeIngredient
        {
            get { return typeIngredient; }
            private set { 
                if (typeIngredient == null)
                    throw new NullIngredientException("Type Ingredient");

                typeIngredient = value; 
            }
        }
    }
}