/// <summary>
/// Name: Sky Martin
/// Student: ST10286905
/// Module: PROG6221
/// References: https://learn.microsoft.com/en-us/dotnet/api/system.enum.getvalues?view=netframework-4.8
///             https://learn.microsoft.com/en-us/dotnet/api/system.array.findlast?view=netframework-4.8
///             https://www.bytehide.com/blog/enum-to-array-csharp
///             https://www.thespruceeats.com/volume-conversions-chart-1328757
/// </summary>

using System;

namespace RecipeProject.Classes
{
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
    /// <summary>
    /// This class contains an enum to represent different units of measurement,
    /// as well as a method for finding the most appropriate unit of measurement
    /// for a given number of milliliters.
    /// </summary>
    public static class UnitHelper
    {
        // Declare and define units of measurement enum in terms of the number of milliliters per unit.
        public enum Units
        {
            Milliliter = 1,
            Teaspoon = 5,
            Tablespoon = 15,
            Cup = 250,
            Liter = 1000
        };

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Find and return the most appropriate unit of measurement for the given number of milliliters.
        /// Assumes best unit of measurement is unit with nearest mlPerUnit less than given milliliters.
        /// </summary>
        public static Units FindBestUnit(float milliliters)
        {
            // Create units array by getting values of units enum, then casting them to units array.
            Units[] units = (Units[])Enum.GetValues(typeof(Units));
            // Use Array.FindLast method to loop through units array backwards,
            // return first unit where mlPerUnit threshold is below given milliliters
            // (technically last matching element, but the function loops backwards).
            return Array.FindLast(units, mlPerUnit => (int)mlPerUnit <= milliliters);
        }
    }
}
