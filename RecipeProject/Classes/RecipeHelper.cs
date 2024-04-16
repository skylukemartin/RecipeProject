using System;
using System.Text;

namespace RecipeProject.Classes
{
    public class RecipeHelper
    {
        public Recipe Recipe { get; set; }

        // Quality of life lambda function for prompting user input
        Func<string, string> prompt = (prompt) =>
        {
            Console.Write($"{prompt}\n> ");
            return Console.ReadLine() ?? "";
        };

        // Nice redundant main method basically :D
        public void Run()
        {
            string choice = prompt("Hello, welcome to recipe helper!\nWould you like to create a new recipe? (Y/N)");
            if (choice.Length > 0 && choice.ToUpper()[0] != 'Y')
            {
                // User doesn't want to make a new recipe, so quit early
                return;
            }
            // Help the user create a recipe
            CaptureRecipe();

            choice = prompt("Would you like to see the recipe all nice and formatted? (Y/N)");
            if (choice.Length > 0 && choice.ToUpper()[0] != 'Y')
            {
                // User doesn't want to see their formatted recipe, so quit early
                return;
            }
            Console.WriteLine(); // Print empty line for spacing
            Console.WriteLine(Recipe.FormatRecipe());

            choice = prompt("Would you like to scale the ingredient amounts by some factor? (Y/N)");
            if (choice.Length > 0 && choice.ToUpper()[0] != 'Y')
            {
                // User doesn't want to scale their recipe ingredients, so quit early
                return;
            }
            float factor = float.Parse(prompt("Enter factor you would like to scale the ingredient amounts by, e.g. 2 or 0.5 etc"));
            Recipe.ScaleIngredients(factor);

            choice = prompt("Would you like to see the scaled recipe all nice and formatted? (Y/N)");
            if (choice.Length > 0 && choice.ToUpper()[0] != 'Y')
            {
                // User doesn't want to see their newly scaled recipe formatted, so quit early
                return;
            }
            Console.WriteLine(); // Print empty line for spacing
            Console.WriteLine(Recipe.FormatRecipe());

            choice = prompt("Would you like to reset the ingredient amounts back to their original? (Y/N)");
            if (choice.Length > 0 && choice.ToUpper()[0] != 'Y')
            {
                // User doesn't want to reset their recipe's ingredient scales, so quit early
                return;
            }
            Recipe.ResetIngredientScales();

            choice = prompt("Would you like to see the unscaled recipe all nice and formatted? (Y/N)");
            if (choice.Length > 0 && choice.ToUpper()[0] != 'Y')
            {
                // User doesn't want to see newly unscaled recipe formatted, so quit early
                return;
            }
            Console.WriteLine(); // Print empty line for spacing
            Console.WriteLine(Recipe.FormatRecipe());
        }

        // Method which creates and returns recipe based on user input
        public void CaptureRecipe()
        {
            // Prompt user to enter the recipe name
            string recipeName =
                prompt("What would you like to name the recipe?");

            // Prompt user to enter ingredients
            Ingredient[] ingredients = CaptureIngredients();

            // Prompt user to enter steps
            string[] steps = CaptureSteps();

            // Create/initialize recipe object based on captured data
            this.Recipe = new Recipe(recipeName, ingredients, steps);
        }

        Ingredient[] CaptureIngredients()
        {
            // Prompt user for number of ingredients
            int numberOfIngredients = int.Parse(
                prompt("Exactly how many ingredients does this recipe " +
                       "have?")); // TODO: Implement exception handling etc
            // Create ingredients array based on specified number of ingredients
            Ingredient[] ingredients = new Ingredient[numberOfIngredients];

            // Construct option dialog for selecting unit of measurement early
            // Source: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=netframework-4.8
            StringBuilder sb = new StringBuilder();
            sb.Append("Units of measurement:\n");
            string[] unitNames = Enum.GetNames(typeof(UnitHelper.Units));
            for (int i = 0; i < unitNames.Length; i++)
            {
                sb.Append($"{i + 1} - {unitNames[i]}\n");
            }
            string unitOptions = sb.ToString();
            sb.Clear();

            // Capture each ingredient
            for (int i = 0; i < numberOfIngredients; i++)
            {
                // Get name of current ingredient
                string name = prompt($"What is ingredient #{i + 1}'s name?");
                // Get ingredient's unit of measurement
                // Source: https://learn.microsoft.com/en-us/dotnet/api/system.enum.parse?view=netframework-4.8
                // Get UnitHelper.Units from user selected unit's name
                string unitName = unitNames[int.Parse(prompt($"{unitOptions}Enter number to select {name}'s unit of measurement.")) - 1];
                UnitHelper.Units unit = (UnitHelper.Units)Enum.Parse(typeof(UnitHelper.Units), unitName);
                // Get amount of ingredient
                int unitAmount = int.Parse(
                    prompt($"How many {unitName.ToLower()}(s) of {name} is needed?"));
                // Create ingredient and save in ingredients array
                ingredients[i] = new Ingredient(name, unit, unitAmount);
            }

            // return the populated ingredients array
            return ingredients;
        }

        string[] CaptureSteps()
        {
            // Find out how many steps the recipe has
            int numberOfSteps = int.Parse(
                prompt("Exactly how many steps does this recipe have?"));
            // Initialize array for storing each of the recipe's steps
            string[] steps = new string[numberOfSteps];

            // Capture and save each of the steps in steps array
            for (int i = 0; i < numberOfSteps; i++)
            {
                steps[i] = prompt($"What is step #{i + 1}");
            }

            // Return populated steps array
            return steps;
        }
    }
}
