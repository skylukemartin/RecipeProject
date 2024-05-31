/// <summary>
/// Name: Sky Martin
/// Student: ST10286905
/// Module: PROG6221
/// References: https://learn.microsoft.com/en-us/dotnet/api/system.enum.parse?view=netframework-4.8
///             https://www.bytehide.com/blog/enum-to-array-csharp
/// </summary>

namespace RecipeProject.Classes
{
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
    /// <summary>
    /// This class contains methods to help users create recipes, scale ingredients, and display formatted recipes.
    /// </summary>
    public class RecipeHelper
    {
        // Create an empty List<Recipe> instance for the recipes.
        public List<Recipe> Recipes { get; set; } = [];

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Display the main menu and call relevant functions based on interactive user input.
        /// </summary>
        public void MainMenu()
        {
            // Display Menu Name
            ColorConsole.WriteLine("{yellow:Recipe Helper} - {green:Main Menu}");

            // Uncomment this to add sample recipes to the List<Recipes> instance
            // if (Recipes.Count < 1)
            // {
            //     Recipes.AddRange(SampleDebugRecipes());
            //     SortRecipes();
            // }

            // Declare menu actions
            var menuActions = new List<(string Name, Action Action)>
            { // Define initial menu actions
                ("Create Recipe", CreateRecipe),
            };

            if (Recipes.Count > 0) // Check if any recipes exist yet.
                menuActions.AddRange( // Add menu actions which depend upon recipes existing.
                    new List<(string Name, Action Action)>
                    {
                        ("List All Recipes", ListAllRecipes),
                        ("Display Recipe", () => DisplayRecipe(SelectRecipe())),
                        ("Select Recipe", () => RecipeMenu(SelectRecipe()))
                    }
                );

            menuActions.Add(("Quit", () => { })); // Add quit action.

            int selIndex = PromptSafe.EnterOptionNum(
                "Enter number to select menu option",
                menuActions.Select(a => a.Name).ToArray()
            );

            var selAction = menuActions[selIndex];
            if (selAction.Name == "Quit")
                return;
            selAction.Action();
            PromptSafe.WaitReady();

            MainMenu(); // Show this menu again until the user wishes to quit.
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Prompt the user to select a recipe, returning the selected recipe.
        /// </summary>
        Recipe SelectRecipe()
        {
            ColorConsole.WriteLine("Recipe Helper - Select Recipe Menu");

            // Display the names of the current recipes, prompt user to select one,
            // then save reference to the instance of the selected recipe.
            Recipe recipe = Recipes[
                PromptSafe.EnterOptionNum(
                    "Enter number to select recipe.",
                    Recipes.Select(recipe => recipe.Name).ToArray()
                )
            ];

            return recipe;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Sort the recipes list in alphabetical order by name.
        /// </summary>
        public void SortRecipes() => Recipes.Sort((a, b) => string.Compare(a.Name, b.Name));

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Display the name of each recipe with fancy formatting.
        /// </summary>
        void ListAllRecipes()
        {
            ColorConsole.WriteLine("{yellow:~~~~~~~~~}{red:All Recipes}{yellow:~~~~~~~~~}");
            int c = 0;
            Recipes.ForEach(rec => // Display each recipe name
                ColorConsole.WriteLine( // With an alternating decorator char on the left
                    "{yellow:" + (c++ % 2 == 1 ? "/" : "\\") + "}  " + "{green:" + rec.Name + "}"
                )
            );
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// The recipe menu for the given recipe, where each option action is specific to that recipe.
        /// </summary>
        void RecipeMenu(Recipe recipe)
        {
            ColorConsole.WriteLine("Recipe Helper - Recipe Menu");

            // Declare menu actions
            var menuActions = new List<(string Name, Action<Recipe> Action)>
            { // Define menu actions
                ("Display Recipe", DisplayRecipe),
                ("Scale Recipe", ScaleRecipe),
                ("Reset Recipe Scale", ResetRecipeScale),
                ("Remove Recipe", RemoveRecipe),
                ("Back", (_) => { })
            };

            // Prompt user to select menu action, saving its index
            var selIndex = PromptSafe.EnterOptionNum(
                $"Enter number to select action for the ${recipe.Name} recipe.",
                menuActions.Select(a => a.Name).ToArray()
            );

            // Get selected menu action
            var selAction = menuActions[selIndex];
            if (selAction.Name == "Back")
                return; // Return to main menu.

            selAction.Action(recipe);
            PromptSafe.WaitReady();
            if (selAction.Name != "Remove Recipe")
                RecipeMenu(recipe); // Recipe still exists, show this menu again.
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Warn and confirm whether the user really wishes to clear the recipe, clearing it upon confirmation.
        /// </summary>
        void RemoveRecipe(Recipe recipe)
        {
            ColorConsole.WriteLine(
                $"Warning: This will completely remove the {recipe.Name} recipe from the recipe list."
            );
            if (PromptSafe.AskConfirm("Are you sure you would like to remove the recipe?"))
                Recipes.Remove(recipe);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Display the recipe in a nice format.
        /// </summary>
        void DisplayRecipe(Recipe recipe)
        {
            ColorConsole.WriteLine(); // Print empty line for spacing
            recipe.DisplayColoredRecipe();
            ColorConsole.WriteLine(); // Print another empty line for spacing
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Scale the recipe based on user selected scaling factor.
        /// </summary>
        void ScaleRecipe(Recipe recipe)
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
                        "Enter factor you would like to scale the ingredient amounts by, e.g. 2 or 0.5 etc",
                        min: 0f
                    );
                    break;
                default:
                    ColorConsole.WriteLine(
                        "Error: something went terribly wrong. How did you get here?",
                        "red"
                    );
                    factor = 1f;
                    break;
            }
            // Apply the user selected scaling factor to the ingredients.
            recipe.ScaleIngredients(factor);
            // Let the user know that the recipe has been scaled.
            ColorConsole.WriteLine($"The recipe has been scaled by {factor:0.00}", "green");
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Reset recipe's scale factor back to original scale.
        /// </summary>
        void ResetRecipeScale(Recipe recipe)
        {
            recipe.ResetIngredientScales();
            // Let the user know that the recipe's scale has been reset.
            ColorConsole.WriteLine(
                $"The recipe's ingredients have been set back to their original scale.",
                "green"
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

            // Create recipe instance
            Recipe recipe = new(recipeName);

            // Prompt and save user input to new recipe
            InputIngredients(recipe);

            // Prompt and save user input steps to new recipe
            InputSteps(recipe);

            // Add new recipe to recipe list.
            Recipes.Add(recipe);

            // Apply alphabetical recipe sorting
            SortRecipes();
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Method which creates, populates, and returns an array of recipe ingredients based on user input.
        /// </summary>
        static void InputIngredients(Recipe recipe)
        {
            // Create array of unit names before entering loop.
            string[] unitNames = Enum.GetNames(typeof(UnitHelper.Units));

            // debug
            // recipe.OnCalorieUpdate += (n, o) =>
            //     ColorConsole.WriteLine($"updated calories, {o} => {n}");

            // Capture each ingredient
            int count = 0;
            do
            {
                // Get name of current ingredient
                string name = PromptSafe.EnterString($"What is ingredient #{++count}'s name?");

                // Get the name of the ingredient's unit of measurement
                string unitName = unitNames[
                    PromptSafe.EnterOptionNum("Select unit of measurement:", unitNames)
                ];
                // Get UnitHelper.Units with unit's name, by casting the parsed enum object to its correct type.
                UnitHelper.Units unit = (UnitHelper.Units)
                    Enum.Parse(typeof(UnitHelper.Units), unitName);

                // Get unit amount of ingredient
                int unitAmount = PromptSafe.EnterInt(
                    $"How many {unitName.ToLower()}(s) of {name} is needed?",
                    min: 1,
                    inclusiveMin: true
                );

                // Get calories in amount of ingredient
                int calories = PromptSafe.EnterInt(
                    $"How many calories are in that much {name}?",
                    min: 0,
                    inclusiveMin: true
                );

                // Get the name of the ingredient's food group
                string foodGroup = Ingredient.FoodGroups[
                    PromptSafe.EnterOptionNum("Select food group:", Ingredient.FoodGroups)
                ];

                // Create ingredient and save in ingredients array
                recipe.AddIngredient(new Ingredient(name, unit, unitAmount, calories, foodGroup));
            } while (PromptSafe.AskConfirm("Would you like to add another ingredient?"));
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Method which creates, populates, and returns an array of recipe steps based on user input.
        /// </summary>
        static void InputSteps(Recipe recipe)
        {
            int count = 0;
            do
            {
                recipe.AddStep(PromptSafe.EnterString($"What is step #{++count}"));
            } while (PromptSafe.AskConfirm("Would you like to add another ingredient?"));
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Return a list
        /// </summary>
        static List<Recipe> SampleDebugRecipes() =>
            [
                new Recipe(
                    "Mac n Cheese",
                    [
                        new Ingredient("Butter", UnitHelper.Units.Tablespoon, 4, 123, ""),
                        new Ingredient("Flour", UnitHelper.Units.Tablespoon, 4, 123, ""),
                        new Ingredient("Cheese", UnitHelper.Units.Cup, 3, 123, ""),
                        new Ingredient("Milk", UnitHelper.Units.Liter, 1, 123, ""),
                        new Ingredient("Water", UnitHelper.Units.Liter, 1, 123, ""),
                        new Ingredient("Macaroni", UnitHelper.Units.Liter, 1, 123, "")
                    ],
                    [
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
                    ]
                ),
                new Recipe(
                    "Chocolate Chip Cookies",
                    [
                        new Ingredient("Butter", UnitHelper.Units.Cup, 1, 123, ""),
                        new Ingredient("White Sugar", UnitHelper.Units.Cup, 1, 123, ""),
                        new Ingredient("Brown Sugar", UnitHelper.Units.Cup, 1, 123, ""),
                        new Ingredient("Eggs", UnitHelper.Units.Cup, 2, 123, ""),
                        new Ingredient("Vanilla Extract", UnitHelper.Units.Teaspoon, 2, 123, ""),
                        new Ingredient("Baking Soda", UnitHelper.Units.Teaspoon, 1, 123, ""),
                        new Ingredient("Hot Water", UnitHelper.Units.Tablespoon, 2, 123, ""),
                        new Ingredient("Salt", UnitHelper.Units.Teaspoon, 1, 123, ""),
                        new Ingredient("Flour", UnitHelper.Units.Cup, 3, 123, ""),
                        new Ingredient("Chocolate Chips", UnitHelper.Units.Cup, 2, 123, ""),
                        new Ingredient("Chopped Walnuts", UnitHelper.Units.Cup, 1, 123, "")
                    ],
                    [
                        "Preheat oven to 175 degrees C.",
                        "Cream together the butter, white sugar, and brown sugar until smooth.",
                        "Beat in the eggs one at a time, then stir in the vanilla.",
                        "Dissolve baking soda in hot water. Add to batter along with salt.",
                        "Stir in flour, chocolate chips, and nuts.",
                        "Drop by large spoonfuls onto ungreased pans.",
                        "Bake for about 10 minutes in the preheated oven, or until edges are nicely browned."
                    ]
                )
            ];
    }
}
