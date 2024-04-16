using System;

namespace RecipeProject.Classes
{
    public static class PromptSafe
    {
        // Display formatted message, then get and return user input as string
        public static string EnterString(string msg)
        {
            // Skip a line, print the message, then add a '>' to the next line and get user input
            Console.Write($"\n{msg}\n> ");
            string response = Console.ReadLine() ?? "";
            Console.WriteLine(); // Add yet another empty line for spacing.
            return response;
        }

        // Display formatted message, then get, validate, and return user input as int
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

        // Display formatted message, then get, validate, and return user input as float
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

        // Display numbered option names, display formatted message,
        // get and validate user input number, returns when valid, keeps asking until valid.
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

        // Prompt the user if they would like to continue or quit, returns true if they wish to continue.
        public static bool AskContinue()
        {
            const string msg = "Press enter to continue, or Q followed by enter to quit";
            bool shouldContinue = !EnterString(msg).ToUpper().StartsWith("Q");
            return shouldContinue;
        }

        // Prompt the user for confirmation, returning false if that doesn't begin with "Y" is given.
        public static bool AskConfirm(string msg)
        {
            return EnterString($"{msg} (Y/N)").ToUpper().StartsWith("Y");
        }
    }
}
