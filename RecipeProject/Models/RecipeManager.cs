/// <summary>
/// Name: Sky Martin
/// Student: ST10286905
/// Module: PROG6221
/// References: https://www.youtube.com/watch?v=4v8PobcZpqM
/// </summary>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeProject.Models
{
    class RecipeManager
    {
        public static ObservableCollection<Recipe> _recipes = new ObservableCollection<Recipe>(); // = SampleDebugRecipes();

        public static event EventHandler RecipesChanged;

        public static ObservableCollection<Recipe> GetRecipes()
        {
            return _recipes;
        }

        public static void AddRecipe(Recipe recipe)
        {
            _recipes.Add(recipe);
            OnRecipesChanged();
        }

        public static void RemoveRecipe(Recipe recipe)
        {
            _recipes.Remove(recipe);
            OnRecipesChanged();
        }

        private static void OnRecipesChanged()
        {
            RecipesChanged?.Invoke(null, EventArgs.Empty);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Debug recipes
        /// </summary>
        static ObservableCollection<Recipe> SampleDebugRecipes() =>
            new ObservableCollection<Recipe>
            {
                new Recipe(
                    "Mac n Cheese",
                    new List<Ingredient>
                    {
                        new Ingredient("Butter", Volume.Unit.Tablespoon, 4, 123, "Dairy"),
                        new Ingredient("Flour", Volume.Unit.Tablespoon, 4, 123, "Starch"),
                        new Ingredient("Cheese", Volume.Unit.Cup, 3, 123, "Dairy"),
                        new Ingredient("Milk", Volume.Unit.Liter, 1, 123, "Dairy"),
                        new Ingredient("Water", Volume.Unit.Liter, 1, 123, "Water"),
                        new Ingredient("Macaroni", Volume.Unit.Liter, 1, 123, "Starch")
                    },
                    new List<string>
                    {
                        "Heat water in a pot for the macaroni",
                        "Once boiling, add macaroni and stir for 11 minutes before straining",
                        "Heat a pot for the sauce",
                        "Add butter to sauce pot, optionally with herbs/spices of your choice",
                        "Wait for butter to melt",
                        "Add flour to sauce pot",
                        "Mix flour thoroughly into butter to avoid lumps",
                        "Slowly pour milk into sauce pot while carefully stirring",
                        "Continuously stir sauce as it heats up",
                        "Once warm enough, add a third of the cheese to the sauce pot",
                        "As soon as the sauce bubbles/boils it's ready, immediately take it off the heat",
                        "Put macaroni back into the now empty pot it was boiled in (without water this time)",
                        "Pour all the sauce into the same pot with the macaroni and mix gently",
                        "Once mixed, pour the saucy macaroni into a baking dish",
                        "Put the rest of the cheese on top",
                        "Bake in oven until cheese is golden brown or melted the way you like it",
                        "Enjoy"
                    }
                ),
                new Recipe(
                    "Chocolate Chip Cookies",
                    new List<Ingredient>
                    {
                        new Ingredient("Butter", Volume.Unit.Cup, 1, 123, ""),
                        new Ingredient("White Sugar", Volume.Unit.Cup, 1, 123, ""),
                        new Ingredient("Brown Sugar", Volume.Unit.Cup, 1, 123, ""),
                        new Ingredient("Eggs", Volume.Unit.Cup, 2, 123, ""),
                        new Ingredient("Vanilla Extract", Volume.Unit.Teaspoon, 2, 123, ""),
                        new Ingredient("Baking Soda", Volume.Unit.Teaspoon, 1, 123, ""),
                        new Ingredient("Hot Water", Volume.Unit.Tablespoon, 2, 123, ""),
                        new Ingredient("Salt", Volume.Unit.Teaspoon, 1, 123, ""),
                        new Ingredient("Flour", Volume.Unit.Cup, 3, 123, ""),
                        new Ingredient("Chocolate Chips", Volume.Unit.Cup, 2, 123, ""),
                        new Ingredient("Chopped Walnuts", Volume.Unit.Cup, 1, 123, "")
                    },
                    new List<string>
                    {
                        "Preheat oven to 175 degrees C.",
                        "Cream together the butter, white sugar, and brown sugar until smooth.",
                        "Beat in the eggs one at a time, then stir in the vanilla.",
                        "Dissolve baking soda in hot water. Add to batter along with salt.",
                        "Stir in flour, chocolate chips, and nuts.",
                        "Drop by large spoonfuls onto ungreased pans.",
                        "Bake for about 10 minutes in the preheated oven, or until edges are nicely browned."
                    }
                )
            };
    }
}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~FILE END~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
