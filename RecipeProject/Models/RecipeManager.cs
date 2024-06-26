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
        public static ObservableCollection<Recipe> _recipes;

        public static ObservableCollection<Recipe> GetRecipes()
        {
            return _recipes;
        }

        public static void AddRecipe(Recipe recipe) { 
            _recipes.Add(recipe);
        }
    }
}
