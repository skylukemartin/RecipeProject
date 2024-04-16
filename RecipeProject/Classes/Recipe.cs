/// <summary>
/// Name: Sky Martin
/// Student: ST10286905
/// Module: PROG6221
/// References: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=netframework-4.8
/// </summary>

using System.Text;

namespace RecipeProject.Classes
{
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
    /// <summary>
    /// This class represents a recipe, including its name, ingredients, and steps.
    /// Provides methods to create and return a fully formatted recipe string,
    /// scale ingredient quantities, and reset ingredient quantity scales.
    /// </summary>
    public class Recipe
    {
        // Declare recipe's member variables
        public string Name { get; set; }
        public Ingredient[] Ingredients { get; set; }
        public string[] Steps { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Recipe class constructor, sets recipe's name, ingredients, and steps, to the arguments provided.
        /// </summary>
        public Recipe(string name, Ingredient[] ingredients, string[] steps)
        {
            Name = name;
            Ingredients = ingredients;
            Steps = steps;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This method builds and returns a string containing the fully formatted representation of the recipe,
        /// including its name, quantity of ingredient, and all of its steps.
        /// </summary>
        public string FormatRecipe()
        {
            // Use StringBuilder to construct the formatted string (while avoiding the IDE's annoying squiggly lines).
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($".. Recipe: {Name}"); // Name goes at the top
            sb.AppendLine("|"); // Format connection bar/line
            sb.AppendLine("|.... Ingredients:"); // Next is ingredients
            foreach (var ingredient in Ingredients)
            {
                // Add each formatted ingredient
                sb.AppendLine($"|  |.... {ingredient.ReadableAmount()} {ingredient.Name}");
            }
            sb.AppendLine("|"); // Another format connection line/bar
            sb.AppendLine("|.... Steps:"); // Now for the steps
            for (int i = 0; i < Steps.Length; i++)
            {
                // Add each formatted step
                sb.AppendLine($"   |.... {i + 1}. {Steps[i]}");
            }
            // Finally, return the freshly built and formatted string.
            return sb.ToString();
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This method applies the scale factor to each ingredient and updates its unit of measurement.
        /// </summary>
        public void ScaleIngredients(float factor)
        {
            // Loop through each ingredient in the recipe.
            for (int i = 0; i < Ingredients.Length; i++)
            {
                // Apply the scale factor to each ingredient in the recipe, which also updates its unit.
                Ingredients[i].ApplyScaleFactor(factor);
            }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This method applies the scale factor to each ingredient and updates its unit of measurement.
        /// </summary>
        public void ResetIngredientScales()
        {
            // Loop through each ingredient in the recipe.
            for (int i = 0; i < Ingredients.Length; i++)
            {
                // Reset scale factor of each ingredient in the recipe, also updating its unit.
                Ingredients[i].ResetScaleFactor();
            }
        }
    }
}
