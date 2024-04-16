using System;

namespace RecipeProject.Classes
{
    public class Ingredient
    {
        public string Name { get; set; } // Name of ingredient
        public int Amount { get; set; } // Measured in ml
        public UnitHelper.Units Unit { get; set; } // The unit of measurement
        public float ScaleFactor { get; set; } = 1; // Scale factor for scaling ingredient amount

        public Ingredient(string name, UnitHelper.Units unit, int unitAmount)
        {
            Name = name;
            Amount = unitAmount * ((int)unit);
            Unit = unit;
        }

        public void ApplyScaleFactor(float factor)
        {
            ScaleFactor *= factor;
            UpdateUnit();
        }

        public void ResetScaleFactor()
        {
            ScaleFactor = 1;
            // This runs the risk of changing the user's original unit of measurement to one that closer matches the quantity ...
            UpdateUnit();
        }

        public void UpdateUnit()
        {
            Unit = UnitHelper.FindBestUnit(Amount * ScaleFactor);
        }

        public string ReadableAmount()
        {
            float amount = Amount * ScaleFactor / ((int)Unit);
            string name = Enum.GetName(typeof(UnitHelper.Units), Unit);
            if (amount > 1)
            {
                name += "s";
            }
            // Source for rounded float format: https://stackoverflow.com/a/58733847
            return $"{amount:0.00} {name}";
        }
    }
}