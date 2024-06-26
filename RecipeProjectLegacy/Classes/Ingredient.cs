/// <summary>
/// Name: Sky Martin
/// Student: ST10286905
/// Module: PROG6221
/// References: https://stackoverflow.com/a/58733847
///             https://sweetlife.org.za/what-are-the-different-food-groups-a-simple-explanation/
/// </summary>

using System;

namespace RecipeProjectLegacy.Classes
{
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
    /// <summary>
    /// This class represents an ingredient, including its name, amount, and unit of measurement.
    /// Provides methods to apply scale factor, reset scale factor, update unit of measurement,
    /// and return a string representing its amount in a neat and readable format.
    /// </summary>
    public class Ingredient
    {
        // Declare ingredient's member variables
        public string Name { get; set; } // Name of ingredient
        public int Amount { get; set; } // Amount measured in ml
        public UnitHelper.Units Unit { get; set; } // The unit of measurement
        public float ScaleFactor { get; set; } = 1; // Scale factor to scale ingredient amount
        public float Calories { get; set; } // Calories of the ingredient, in terms of the initial ingredient quantity.
        public string FoodGroup { get; set; } // Name of food group

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Constructor for ingredient class. Sets the ingredient's name, unit, unitAmount, and calories.
        /// </summary>
        public Ingredient(
            string name,
            UnitHelper.Units unit,
            int unitAmount,
            int calories,
            string foodGroup
        )
        {
            Name = name;
            Amount = unitAmount * ((int)unit);
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This method applies the provided factor to the ingredient's scale factor using multiplication.
        /// Note that this method does not overwrite the scale factor with the provided factor,
        /// instead it multiplies the current scale factor by the provided factor. This allows compound scaling.
        /// </summary>
        public void ApplyScaleFactor(float factor)
        {
            ScaleFactor *= factor;
            UpdateUnit();
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This method resets the ingredient's scale factor back to its original value, which is 1.
        /// Also updates the ingredient's unit of measurement to the one most suitable for representing its amount.
        /// Note that the original unit of measurement selected by the user might not be restored
        /// if a different unit of measurement better represents the amount.
        /// </summary>
        public void ResetScaleFactor()
        {
            ScaleFactor = 1;
            UpdateUnit();
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This method updates the ingredient's unit of measurement to best represents its amount (includes scaling).
        /// </summary>
        public void UpdateUnit()
        {
            // Set unit to the result returned by the unit helper's find best unit function.
            Unit = UnitHelper.FindBestUnit(Amount * ScaleFactor);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This method returns a neatly formatted and readable string representing the ingredient's
        /// amount, unit of measurement, and name.
        /// </summary>
        public static string ReadableAmount(int amount, float scaleFactor, UnitHelper.Units unit)
        {
            // Calculate exact amount based on scale factor, in terms of ingredient's unit of measurement.
            float scaledAmount = amount * scaleFactor / ((int)unit);
            // Don't use decimal places if amount is a whole number, else use 2 (0.00) decimal places.
            string roundedAmount =
                scaledAmount % 1 == 0 ? $"{scaledAmount:0}" : $"{scaledAmount:0.00}";

            // Get the name of the unit of measurement in lowercase.
            string unitName = Enum.GetName(typeof(UnitHelper.Units), unit).ToLower();

            // If there's more than one, add an 's' to make the unit name plural
            if (scaledAmount > 1)
                unitName += "s";

            // Finally, return the nicely formatted amount as a string.
            return $"{roundedAmount} {unitName} of";
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This method returns a neatly formatted and readable string representing the ingredient's
        /// amount, unit of measurement, calories, food group, and name.
        /// </summary>
        public string ReadableAmount() => ReadableAmount(Amount, ScaleFactor, Unit);

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// This static readonly string array contains food groups that an ingredient could belong to.
        /// </summary>
        public static readonly string[] FoodGroups = new string[]
        {
            "Starchy foods",
            "Vegetables and fruits",
            "Dry beans, peas, lentils and soya",
            "Chicken, fish, meat and eggs",
            "Milk and dairy products",
            "Fats and oil",
            "Water"
        };
    }
}
