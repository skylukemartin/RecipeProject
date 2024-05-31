/// <summary>
/// Name: Sky Martin
/// Student: ST10286905
/// Module: PROG6221
/// References: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/static
/// </summary>

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
            ColorConsole.Write($"\n{msg}\n" + "{green:>} ");
            string response = Console.ReadLine() ?? "";
            ColorConsole.WriteLine(); // Add yet another empty line for spacing.
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
                    ColorConsole.WriteLine("Invalid input. Please enter a whole number.", "red");
                }
            } while (true); // Loop until valid input
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Prompts user with provided message, returns their response as an integer.
        /// Validates the input to ensure it is a whole number, and at least above min (or min if inclusiveMin=true).
        /// </summary>
        public static int EnterInt(string msg, float min, bool inclusiveMin = false)
        {
            int input = -1;
            do
            {
                input = EnterInt(msg);
                if (inclusiveMin ? input >= min : input > min)
                    break;
                ColorConsole.WriteLine($"Please enter a number greater than {min}", "red");
            } while (input < min);
            return input;
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
                    ColorConsole.WriteLine("Invalid input. Please enter a number.", "red");
                }
            } while (true); // Loop until valid input
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Prompts user with provided message, returns their response as a float.
        /// Validates the input to ensure it is a numeric value,
        /// and at least above min (or min if inclusiveMin=true).
        /// </summary>
        public static float EnterFloat(string msg, float min, bool inclusiveMin = false)
        {
            float input = -1;
            do
            {
                input = EnterFloat(msg);
                if (inclusiveMin ? input >= min : input > min)
                    break;
                ColorConsole.WriteLine($"Please enter a number greater than {min}", "red");
            } while (true);
            return input;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Prompts user to select an option, displaying elements of provided options array as numbered options
        /// with provided message, returns the index of the selected array option/element.
        /// Validates the selection to ensure it is within the range of provided options.
        /// </summary>
        public static int EnterOptionNum(string msg, string[] options)
        { // Declare and define an integer to store the index of the option selected by user.
            int selIndex = -1;
            do
            {
                // Output options for selection
                for (int i = 0; i < options.Length; i++)
                    ColorConsole.WriteLine($$"""{yellow:{{i + 1}}} - {{options[i]}}""");

                // Prompt user to enter option
                selIndex = EnterInt(msg) - 1; // minus 1 because options are part of 0-indexed array.

                // Check if option is within valid range
                if (selIndex >= 0 && selIndex < options.Length)
                    break; // Option is within valid range, so return it

                ColorConsole.WriteLine("Invalid option selected.", "red"); // Explain what went wrong
            } while (true);
            return selIndex;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Prompts the user to continue or quit the application.
        /// Returns true if the user's response begins with anything besides 'Q'.
        /// </summary>
        public static bool AskQuitOrContinue()
        {
            const string msg =
                "Press {green:enter} to {green:continue}, or {red:Q} followed by {red:enter} to {red:quit} this menu";
            bool shouldContinue = !EnterString(msg).ToUpper().StartsWith("Q");
            return shouldContinue;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Prompts the user to continue, giving them a chance to read output.
        /// </summary>
        public static void WaitReady()
        {
            const string msg = "Press {green:enter} when ready to {green:continue}";
            EnterString(msg);
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
