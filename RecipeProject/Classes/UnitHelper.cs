using System;

namespace RecipeProject.Classes
{
    public static class UnitHelper
    {
        public static MeasurementUnit[] Units { get; } = new MeasurementUnit[]
        {
            new MeasurementUnit("milliliter", 1),
            new MeasurementUnit("teaspoon", 5),
            new MeasurementUnit("tablespoon", 15),
            new MeasurementUnit("cup", 250),
            new MeasurementUnit("liter", 1000)
        };

        // Find and return the best unit for the given number of milliliters.
        // Assuming the best unit of measurement is the one with the
        // closest mlPerUnit below the given milliliters.
        public static MeasurementUnit FindBestUnit(float milliliters)
        {
            int bestIndex = 0;
            for (int i = 1; i < Units.Length; i++)
            {
                if (milliliters > Units[i].MlPerUnit)
                    bestIndex = i;
                else
                    break;
            }
            return Units[bestIndex];
        }
    }
}