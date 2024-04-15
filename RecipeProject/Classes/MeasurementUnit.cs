namespace RecipeProject.Classes
{
    public class MeasurementUnit
    {
        public string Name { get; set; }
        public int MlPerUnit { get; set; }

        public MeasurementUnit(string name, int mlPerUnit)
        {
            Name = name;
            MlPerUnit = mlPerUnit;
        }
    }
}