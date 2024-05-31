/// <summary>
/// Name: Sky Martin
/// Student: ST10286905
/// Module: PROG6221
/// References: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=netframework-4.8
/// </summary>

using System.Collections.Generic;
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

        public delegate void CalorieUpdate(float newCals, float prevCals);
        public CalorieUpdate OnCalorieUpdate { get; set; }
        float _calories = 0;
        public float Calories
        {
            get => _calories;
            set
            {
                if (OnCalorieUpdate != null)
                    OnCalorieUpdate(value, _calories);
                _calories = value;
            }
        }

        // Declare recipe's ingredient list variables
        void AddCalories(Ingredient ing) => Calories += (ing.Calories * ing.ScaleFactor);

        void SubCalories(Ingredient ing) => Calories -= (ing.Calories * ing.ScaleFactor);

        List<Ingredient> ingredients = new List<Ingredient>();

        List<string> steps { get; set; } = new List<string>();

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Recipe class constructor, sets name to given argument.
        /// </summary>
        public Recipe(string name)
        {
            Name = name;
            OnCalorieUpdate += NotifyCaloriesSurpass300;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Recipe class constructor. Argument values are used to set the recipe's name, ingredients, and steps.
        /// </summary>
        public Recipe(string name, List<Ingredient> ingredients, List<string> steps)
        {
            Name = name;
            OnCalorieUpdate += NotifyCaloriesSurpass300;
            ingredients.ForEach(ing => AddIngredient(ing)); // Make sure all calories are accounted for.
            this.steps = steps;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This method compares given values, checking whether newValue has just surpassed min.
        /// </summary>
        public static bool JustSurpassedMin(float newValue, float oldValue, float min) =>
            newValue > min && oldValue <= min;

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This method checks given newCals and prevCals with the JustSurpassedMin method and minimum value of 300.
        /// If JustSurpassedMin evaluates to true, prints notification message to the console.
        /// </summary>
        public void NotifyCaloriesSurpass300(float newCals, float prevCals)
        {
            if (JustSurpassedMin(newCals, prevCals, 300))
                ColorConsole.WriteLine("{yellow:Note}: total {yellow:calories} exceed {red:300}!");
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This method adds an ingredient to the list and adds its calories to the total.
        /// </summary>
        public void AddIngredient(Ingredient ingredient)
        {
            AddCalories(ingredient);
            ingredients.Add(ingredient);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This method adds step to the recipe instructions. It is for consistency with AddIngredient method.
        /// </summary>
        public void AddStep(string step) => steps.Add(step);

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
            sb.AppendLine($"|.... Total Calories: {Calories}"); // Next is total calories
            sb.AppendLine("|.... Ingredients:"); // Next is ingredients

            foreach (var ingredient in ingredients)
            {
                // Add each formatted ingredient
                sb.AppendLine($"|  |.... {ingredient.ReadableAmount()} {ingredient.Name}");
            }
            sb.AppendLine("|"); // Another format connection line/bar
            sb.AppendLine("|.... Steps:"); // Now for the steps
            for (int i = 0; i < steps.Count; i++)
            {
                // Add each formatted step
                sb.AppendLine($"   |.... {i + 1}. {steps[i]}");
            }

            // Finally, return the freshly built and formatted string.
            return sb.ToString();
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This method calls FormatRecipe, then prints it with colors.
        /// </summary>
        public void DisplayColoredRecipe() =>
            ColorConsole.WriteLine(
                FormatRecipe()
                    .Replace("|", "{blue:|}")
                    .Replace(".. Recipe", "{darkcyan:.. Recipe}")
                    .Replace("....", "{darkcyan:....}")
                    .Replace(Name, "{yellow:" + Name + "}")
                    .Replace("Total Calories", "{red:Total Calories}")
                    .Replace("Ingredients", "{green:Ingredients}")
                    .Replace("Steps", "{magenta:Steps}")
            );

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This method applies the scale factor to each ingredient and updates its unit of measurement.
        /// Updates recipe's total calories based on new scale. Temporarily supresses calorie notify callback.
        /// </summary>
        public void ScaleIngredients(float factor)
        {
            OnCalorieUpdate -= NotifyCaloriesSurpass300; // Suppress calory notify callback spam
            Calories = 0;
            ingredients.ForEach(ing =>
            {
                ing.ApplyScaleFactor(factor);
                AddCalories(ing);
            });
            OnCalorieUpdate += NotifyCaloriesSurpass300; // Restore calory notify callback spam
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This method applies the scale factor to each ingredient and updates its unit of measurement.
        /// Updates recipe's total calories based on new scale. Temporarily supresses calorie notify callback.
        /// </summary>
        public void ResetIngredientScales()
        {
            OnCalorieUpdate -= NotifyCaloriesSurpass300; // Suppress calorie notify callback spam
            Calories = 0;
            ingredients.ForEach(ing =>
            {
                ing.ResetScaleFactor();
                AddCalories(ing);
            });
            OnCalorieUpdate += NotifyCaloriesSurpass300; // Restore calorie notify callback spam
        }
    }
}
