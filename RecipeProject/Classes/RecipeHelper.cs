using System;

namespace RecipeProject.Classes
{
    public class RecipeHelper
    {
        public Recipe Recipe { get; set; }

        public void MainMenu()
        {
            // Define menu entries for when a recipe doesn't/does exist.
            string[] optionsNoRecipe = { "Create New Recipe", "Quit" };
            string[] optionsRecipe =
            {
                "Display Recipe",
                "Scale Recipe",
                "Reset Recipe Scale",
                "Clear Recipe",
                "Quit"
            };
            string[] options = optionsNoRecipe;

            do
            {
                Console.WriteLine("Recipe Helper - Main Menu");
                int selOption = PromptSafe.EnterOptionNum("Enter number to select option", options);

                switch (options[selOption])
                {
                    case "Create New Recipe":
                        CreateRecipe();
                        break;
                    case "Display Recipe":
                        DisplayRecipe();
                        break;
                    case "Scale Recipe":
                        ScaleRecipe();
                        break;
                    case "Reset Recipe Scale":
                        ResetRecipeScale();
                        break;
                    case "Clear Recipe":
                        ClearRecipe();
                        break;
                    case "Quit":
                        return; // User wants to quit, so return to exit
                    default:
                        Console.WriteLine("Error: selected option not implemented.");
                        break;
                }

                // Update options array depending on whether or not a recipe exists
                options = Recipe != null ? optionsRecipe : optionsNoRecipe;
            } while (PromptSafe.AskContinue());
        }

        // First warn and confirm the user really wants to clear the recipe, then clear it if they are sure.
        void ClearRecipe()
        {
            Console.WriteLine("Warning: This will completely clear the current recipe.");
            if (PromptSafe.AskConfirm("Are you sure you would like to clear the current recipe?"))
            {
                Recipe = null; // Set recipe back to nothing.
            }
        }

        void DisplayRecipe()
        {
            Console.WriteLine(); // Print empty line for spacing
            Console.WriteLine(Recipe.FormatRecipe());
            Console.WriteLine(); // Print another empty line for spacing
        }

        void ScaleRecipe()
        {
            // TODO: Correct this to assignment instructions, (only allowing scaling by 0.5, 2, or 3 ..)
            float factor = PromptSafe.EnterFloat(
                "Enter factor you would like to scale the ingredient amounts by, e.g. 2 or 0.5 etc"
            );
            Recipe.ScaleIngredients(factor);
            Console.WriteLine($"The recipe has been scaled by {factor:0.00}");
        }

        void ResetRecipeScale()
        {
            Recipe.ResetIngredientScales();
            Console.WriteLine(
                $"The recipe's ingredients have been set back to their original scale."
            );
        }

        // Method which creates and returns recipe based on user input
        void CreateRecipe()
        {
            // Prompt user to enter the recipe name
            string recipeName = PromptSafe.EnterString("What would you like to name the recipe?");

            // Prompt and save user input ingredients
            Ingredient[] ingredients = InputIngredients();

            // Prompt and save user input steps
            string[] steps = InputSteps();

            // Create/initialize recipe object based on saved user input
            this.Recipe = new Recipe(recipeName, ingredients, steps);
        }

        Ingredient[] InputIngredients()
        {
            // Prompt user for number of ingredients
            int numberOfIngredients = PromptSafe.EnterInt(
                "Exactly how many ingredients does this recipe have?"
            );
            // Create ingredients array based on specified number of ingredients
            Ingredient[] ingredients = new Ingredient[numberOfIngredients];

            // Create array of unit names before entering loop.
            string[] unitNames = Enum.GetNames(typeof(UnitHelper.Units));

            // Capture each ingredient
            for (int i = 0; i < numberOfIngredients; i++)
            {
                // Get name of current ingredient
                string name = PromptSafe.EnterString($"What is ingredient #{i + 1}'s name?");

                // Get the name of the ingredient's unit of measurement
                string unitName = unitNames[
                    PromptSafe.EnterOptionNum("Select unit of measurement:", unitNames)
                ];
                // Get UnitHelper.Units from unit's name by first parsing .. then casting...
                // Source: https://learn.microsoft.com/en-us/dotnet/api/system.enum.parse?view=netframework-4.8
                UnitHelper.Units unit = (UnitHelper.Units)
                    Enum.Parse(typeof(UnitHelper.Units), unitName);

                // Get amount of ingredient
                int unitAmount = PromptSafe.EnterInt(
                    $"How many {unitName.ToLower()}(s) of {name} is needed?"
                );

                // Create ingredient and save in ingredients array
                ingredients[i] = new Ingredient(name, unit, unitAmount);
            }

            // return the populated ingredients array
            return ingredients;
        }

        string[] InputSteps()
        {
            // Find out how many steps the recipe has
            int numberOfSteps = PromptSafe.EnterInt(
                "Exactly how many steps does this recipe have?"
            );
            // Initialize array for storing each of the recipe's steps
            string[] steps = new string[numberOfSteps];

            // Capture and save each of the steps in steps array
            for (int i = 0; i < numberOfSteps; i++)
            {
                steps[i] = PromptSafe.EnterString($"What is step #{i + 1}");
            }

            // Return populated steps array
            return steps;
        }
    }
}
