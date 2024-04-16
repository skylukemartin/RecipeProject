/// <summary>
/// Name: Sky Martin
/// Student: ST10286905
/// Module: PROG6221
/// References: https://stackoverflow.com/a/58733847
/// </summary>

using System;

namespace RecipeProject.Classes
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

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        /// <summary>
        /// Constructor for ingredient class, setting name, unit, and unitAmount, to provided arguments.
        /// </summary>
        public Ingredient(string name, UnitHelper.Units unit, int unitAmount)
        {
            Name = name;
            Amount = unitAmount * ((int)unit);
            Unit = unit;
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
        public string ReadableAmount()
        {
            // Calculate exact amount based on scale factor, in terms of ingredient's unit of measurement.
            float amount = Amount * ScaleFactor / ((int)Unit);
            // Don't use decimal places if amount is a whole number, else use 2 (0.00) decimal places.
            string roundedAmount = amount % 1 == 0 ? $"{amount:0}" : $"{amount:0.00}";

            // Get the name of the unit of measurement in lowercase.
            string unitName = Enum.GetName(typeof(UnitHelper.Units), Unit).ToLower();
            // If there's more than one, add an 's' to make the unit name plural
            if (amount > 1)
            {
                unitName += "s";
            }
            // Finally, return the nicely formatted amount as a string.
            return $"{roundedAmount} {unitName} of";
        }
    }
}
