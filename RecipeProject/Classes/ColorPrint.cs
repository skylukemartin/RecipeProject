/// <summary>
/// Name: Sky Martin
/// Student: ST10286905
/// Module: PROG6221
/// References: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/static
///             https://stackoverflow.com/questions/2743260/is-it-possible-to-write-to-the-console-in-colour-in-net
/// </summary>

namespace RecipeProject.Classes
{
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
    /// <summary>
    /// This static class contains methods for conveniently writing message output with colors to the console.
    /// </summary>
    public static class ColorConsole
    {
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Sets console color to ConsoleColor color, then writes message to console with Console.Write.
        /// Restores the color back to what is was before calling this function.
        /// </summary>
        public static void Write(string message, ConsoleColor color)
        {
            var initialColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = initialColor;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Sets console color to given string color when successfully parsed to a valid ConsoleColor enum value.
        /// Then writes message to console with Write method above with parsed color, else normal Console.Write.
        /// Restores the color back to what is was before calling this function.
        /// </summary>
        public static void Write(string message, string color)
        {
            ConsoleColor conColor;
            if (Enum.TryParse(color, ignoreCase: true, out conColor))
                Write(message, conColor);
            else
                Console.Write(message);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Prints message with colors. Colors according to the {colorname:text to color} format.
        /// Text outside of {colorname:these braces} is displayed in the default console text color.
        /// </summary>
        public static void Write(string message)
        {
            static int printEscapeColor(string msg, int start)
            { // escape and print colored text,
                int lenny = msg.IndexOf('}', start) - start;
                if (lenny < 0)
                    return -1;
                var splitty = msg.Substring(++start, lenny - 1).Split(':');
                if (splitty.Length != 2)
                    return -1;
                ConsoleColor conclor;
                if (!Enum.TryParse(splitty[0], ignoreCase: true, out conclor))
                    return -1;
                Write(splitty[1], conclor);
                return lenny; // return skip
            }

            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == '{')
                {
                    var skip = printEscapeColor(message, i);
                    if (skip > 0)
                    {
                        i += skip;
                        continue;
                    }
                }
                Console.Write(message[i]);
            }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This method is for consistency with the standard Console.WriteLine, except with color.
        /// and adds a newline.
        /// Sets console color to ConsoleColor color, then writes message to console with Write method above.
        /// Restores the color back to what is was before calling this function.
        /// </summary>
        public static void WriteLine(string message, ConsoleColor color) =>
            Write(message + '\n', color);

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This method is for consistency with the standard Console.WriteLine, except with color.
        /// and adds a newline.
        /// Sets console color to given string color when successfully parsed to a valid ConsoleColor enum value.
        /// Then writes message to console with Write method above with parsed color, else normal Console.Write.
        /// Restores the color back to what is was before calling this function.
        /// </summary>
        public static void WriteLine(string message, string color) => Write(message + '\n', color);

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This method is for consistency with the standard Console.WriteLine, except with color.
        /// and adds a newline.
        /// </summary>
        public static void WriteLine(string messageLine) => Write(messageLine + "\n");

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This method is for consistency with the standard Console.WriteLine, except with color.
        /// and adds a newline.
        /// </summary>
        public static void WriteLine() => Write("\n");

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This method is for demonstration purposes, showing usage and valid string formatting.
        /// </summary>
        public static void Demo() => WriteLine(exampleMoustacheFormat);

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This is an example of valid color formatted string.
        /// Printing this with the above Write(string message) methods will print the string with color.
        /// </summary>
        static readonly string exampleMoustacheFormat = """
            ConsoleColor[] colors =
            [
                {black:ConsoleColor.Black},
                {darkblue:ConsoleColor.DarkBlue},
                {dArKgReEn:ConsoleColor.DarkGreen},
                {darkcyaN:ConsoleColor.DarkCyan},
                {darkred:ConsoleColor.DarkRed},
                {darkmagenta:ConsoleColor.DarkMagenta},
                {DarkYellow:ConsoleColor.DarkYellow},
                {Gray:ConsoleColor.Gray},
                {DarkGray:ConsoleColor.DarkGray},
                {Blue:ConsoleColor.Blue},
                {Green:ConsoleColor.Green},
                {Cyan:ConsoleColor.Cyan},
                {Red:ConsoleColor.Red},
                {Magenta:ConsoleColor.Magenta},
                {Yellow:ConsoleColor.Yellow},
                {White:ConsoleColor.White}
            ];

            """;
    }
}
