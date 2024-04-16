using System.Text;

namespace RecipeProject.Classes
{
    public class Recipe
    {
        public string Name { get; set; }
        public Ingredient[] Ingredients { get; set; }
        public string[] Steps { get; set; }

        public Recipe() { }

        public Recipe(string name, Ingredient[] ingredients, string[] steps)
        {
            Name = name;
            Ingredients = ingredients;
            Steps = steps;
        }

        public string FormatRecipe()
        {
            // My IDE yelled at me for using simple string concatenation and told me to use a string builder.
            // Source: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=netframework-4.8
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($".. Recipe: {Name}");
            sb.AppendLine("|");
            sb.AppendLine("|.... Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                sb.AppendLine($"|  |.... {ingredient.ReadableAmount()} {ingredient.Name}");
            }
            sb.AppendLine("|");
            sb.AppendLine("|.... Steps:");
            for (int i = 0; i < Steps.Length; i++)
            {
                sb.AppendLine($"   |.... {i + 1}. {Steps[i]}");
            }
            return sb.ToString();
        }

        public void ScaleIngredients(float factor)
        {
            for (int i = 0; i < Ingredients.Length; i++)
            {
                Ingredients[i].ApplyScaleFactor(factor);
            }
        }

        public void ResetIngredientScales()
        {
            for (int i = 0; i < Ingredients.Length; i++)
            {
                Ingredients[i].ResetScaleFactor();
            }
        }
    }
}
