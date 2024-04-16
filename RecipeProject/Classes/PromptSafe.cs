/// <summary>
/// Name: Sky Martin
/// Student: ST10286905
/// Module: PROG6221
/// References: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/static
/// </summary>

using System;

namespace RecipeProject.Classes
{
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
    /// <summary>
    /// Static class providing methods for prompting and validating user input.
    /// Handles different data types and provides user relevant feedback if their input is invalid.
    /// </summary>
    public static class PromptSafe
    {
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Prompts user with provided message, returns their response as string.
        /// </summary>
        public static string EnterString(string msg)
        {
            // Skip a line, print the message, then add a '>' to the next line and get user input
            Console.Write($"\n{msg}\n> ");
            string response = Console.ReadLine() ?? "";
            Console.WriteLine(); // Add yet another empty line for spacing.
            return response;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Prompts user with provided message, returns their response as an integer.
        /// Validates the input to ensure it is a whole number.
        /// </summary>
        public static int EnterInt(string msg)
        {
            do
            {
                try
                {
                    return int.Parse(EnterString(msg));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a whole number.");
                }
            } while (true); // Loop until valid input
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Prompts user with provided message, returns their response as a float.
        /// Validates the input to ensure it is a numeric value.
        /// </summary>
        public static float EnterFloat(string msg)
        {
            do
            {
                try
                {
                    return float.Parse(EnterString(msg));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            } while (true); // Loop until valid input
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Prompts user to select an option, displaying elements of provided options array as numbered options
        /// with provided message, returns the index of the selected array option/element.
        /// Validates the selection to ensure it is within the range of provided options.
        /// </summary>
        public static int EnterOptionNum(string msg, string[] options)
        {
            do
            {
                // Output options for selection
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"{i + 1} - {options[i]}");
                }

                // Prompt user to enter option, then minus 1 because options are part of 0-indexed array
                int selOption = EnterInt(msg) - 1;

                // Check if option is within valid range
                if (selOption >= 0 && selOption < options.Length)
                {
                    // Option is within valid range, so return it
                    return selOption;
                }

                // Explain what went wrong
                Console.WriteLine(
                    "Invalid option selected. Please select option number within valid range."
                );
            } while (true); // We must return something, so continue prompting until a valid option is selected.
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Prompts the user to continue or quit the application.
        /// Returns true if the user's response begins with anything besides 'Q'.
        /// </summary>
        public static bool AskContinue()
        {
            const string msg = "Press enter to continue, or Q followed by enter to quit";
            bool shouldContinue = !EnterString(msg).ToUpper().StartsWith("Q");
            return shouldContinue;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Prompts the user for confirmation with provided message.
        /// Returns true if the user's response begins with 'Y'.
        /// </summary>
        public static bool AskConfirm(string msg)
        {
            return EnterString($"{msg} (Y/N)").ToUpper().StartsWith("Y");
        }
    }
}
