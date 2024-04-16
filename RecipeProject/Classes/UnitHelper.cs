using System;

namespace RecipeProject.Classes
{
    public static class UnitHelper
    {
        public enum Units { Milliliter = 1, Teaspoon = 5, Tablespoon = 15, Cup = 250, Liter = 1000 };

        // Find and return the best unit for the given number of milliliters.
        // Assuming the best unit of measurement is the one with the
        // closest mlPerUnit below the given milliliters.
        public static Units FindBestUnit(float milliliters)
        {
            // Sources: https://learn.microsoft.com/en-us/dotnet/api/system.enum.getvalues?view=netframework-4.8
            //          https://learn.microsoft.com/en-us/dotnet/api/system.array.findlast?view=netframework-4.8
            //          https://www.bytehide.com/blog/enum-to-array-csharp
            Units[] units = (Units[])Enum.GetValues(typeof(Units));
            return Array.FindLast(units, unit => (int)unit <= milliliters);
        }
    }
}