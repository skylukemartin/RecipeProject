/// <summary>
/// Name: Sky Martin
/// Student: ST10286905
/// Module: PROG6221
/// References: https://learn.microsoft.com/en-us/dotnet/api/system.enum.parse?view=netframework-4.8
/// </summary>

using System;

namespace RecipeProject.Classes
{
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
    /// <summary>
    /// This class contains methods to help users create recipes, scale ingredients, and display formatted recipes.
    /// </summary>
    public class RecipeHelper
    {
        // Create a new instance of RecipeHelper
        public Recipe Recipe { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Display the main menu and call relevant functions based on interactive user input.
        /// </summary>
        public void MainMenu()
        {
            // Define menu entries for when a recipe doesn't exist.
            string[] optionsNoRecipe = { "Create New Recipe", "Quit" };
            // Define menu entries for when a recipe does exist.
            string[] optionsRecipe =
            {
                "Display Recipe",
                "Scale Recipe",
                "Reset Recipe Scale",
                "Clear Recipe",
                "Quit"
            };

            do
            {
                // Set relevant options based on whether or not a recipe exists.
                string[] options = Recipe != null ? optionsRecipe : optionsNoRecipe;

                // Display menu and let user select an option.
                Console.WriteLine("Recipe Helper - Main Menu");
                int selOption = PromptSafe.EnterOptionNum(
                    "Enter number to select menu option",
                    options
                );

                // Call selected menu option's respective function.
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
                        // User wants to quit, so return from this function and exit.
                        return;
                    default:
                        // This should be unreachable.
                        Console.WriteLine("Error: selected option not implemented.");
                        break;
                }
            } while (PromptSafe.AskContinue()); // Continue or quit based on user's choice.
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Set the current Recipe to a big predefined recipe for testing purposes.
        /// </summary>
        public void SetDebugRecipe()
        {
            Recipe = new Recipe(
                "Mac n Cheese",
                new Ingredient[]
                {
                    new Ingredient("Butter", UnitHelper.Units.Tablespoon, 4),
                    new Ingredient("Flour", UnitHelper.Units.Tablespoon, 4),
                    new Ingredient("Cheese", UnitHelper.Units.Cup, 3),
                    new Ingredient("Milk", UnitHelper.Units.Liter, 1),
                    new Ingredient("Water", UnitHelper.Units.Liter, 1),
                    new Ingredient("Macaroni", UnitHelper.Units.Liter, 1),
                },
                new string[]
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
            );
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Warn and confirm whether the user really wishes to clear the recipe, clearing it upon confirmation.
        /// </summary>
        void ClearRecipe()
        {
            Console.WriteLine("Warning: This will completely clear the current recipe.");
            if (PromptSafe.AskConfirm("Are you sure you would like to clear the current recipe?"))
            {
                Recipe = null; // Set recipe back to nothing.
            }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Display the recipe in a nice format.
        /// </summary>
        void DisplayRecipe()
        {
            Console.WriteLine(); // Print empty line for spacing
            Console.WriteLine(Recipe.FormatRecipe()); // Print the freshly formatted recipe.
            Console.WriteLine(); // Print another empty line for spacing
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Scale the recipe based on user selected scaling factor.
        /// </summary>
        void ScaleRecipe()
        {
            // Initialize factor variable.
            float factor;
            // Define scaling option names.
            string[] scaleOptions = { "Half (0.5)", "Double (2)", "Triple (3)", "Custom" };
            // Get user's option selection.
            int selOpt = PromptSafe.EnterOptionNum(
                "Enter number to select scaling factor option",
                scaleOptions
            );
            // Set scaling factor variable based on selected option.
            switch (scaleOptions[selOpt])
            {
                case "Half (0.5)":
                    factor = 0.5f;
                    break;
                case "Double (2)":
                    factor = 2f;
                    break;
                case "Triple (3)":
                    factor = 3f;
                    break;
                case "Custom":
                    factor = PromptSafe.EnterFloat(
                        "Enter factor you would like to scale the ingredient amounts by, e.g. 2 or 0.5 etc"
                    );
                    break;
                default:
                    Console.WriteLine(
                        "Error: something went terribly wrong. How did you get here?"
                    );
                    factor = 1f;
                    break;
            }
            // Apply the user selected scaling factor to the ingredients.
            Recipe.ScaleIngredients(factor);
            // Let the user know that the recipe has been scaled.
            Console.WriteLine($"The recipe has been scaled by {factor:0.00}");
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Reset recipe's scale factor back to original scale.
        /// </summary>
        void ResetRecipeScale()
        {
            Recipe.ResetIngredientScales();
            // Let the user know that the recipe's scale has been reset.
            Console.WriteLine(
                $"The recipe's ingredients have been set back to their original scale."
            );
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Method which creates recipe based on user input.
        /// </summary>
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

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Method which creates, populates, and returns an array of recipe ingredients based on user input.
        /// </summary>
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
                // Get UnitHelper.Units with unit's name, by casting the parsed enum object to its correct type.
                UnitHelper.Units unit = (UnitHelper.Units)
                    Enum.Parse(typeof(UnitHelper.Units), unitName);

                // Get unit amount of ingredient
                int unitAmount = PromptSafe.EnterInt(
                    $"How many {unitName.ToLower()}(s) of {name} is needed?"
                );

                // Create ingredient and save in ingredients array
                ingredients[i] = new Ingredient(name, unit, unitAmount);
            }

            // return the now populated ingredients array
            return ingredients;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Method which creates, populates, and returns an array of recipe steps based on user input.
        /// </summary>
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
