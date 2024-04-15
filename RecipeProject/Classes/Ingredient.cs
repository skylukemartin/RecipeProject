namespace RecipeProject.Classes
{
    public class Ingredient
    {
        public string Name { get; set; } // Name of ingredient
        public int AmountMl { get; set; } // Measured in ml
        public MeasurementUnit Unit { get; set; } // The unit of measurement
        public float ScaleFactor { get; set; } = 1; // Scale factor for scaling ingredient amount

        public Ingredient(string name, MeasurementUnit unit, int unitAmount)
        {
            Name = name;
            AmountMl = unitAmount * unit.MlPerUnit;
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
            Unit = UnitHelper.FindBestUnit(AmountMl * ScaleFactor);
        }

        public string ReadableAmount()
        {
            float amount = AmountMl * ScaleFactor / Unit.MlPerUnit;
            string name = Unit.Name;
            if (amount > 1)
            {
                name += "s";
            }
            // Source for rounded float format: https://stackoverflow.com/a/58733847
            return $"{amount:0.00} {name}";
        }
    }
}