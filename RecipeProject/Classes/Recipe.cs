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
            // Source: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=netframework-4.8
            StringBuilder sb = new StringBuilder();
            sb.Append($"Recipe: {Name}\n\n");
            sb.Append($"All {Ingredients.Length} of the recipe's ingredients:\n");
            foreach (var ingredient in Ingredients)
            {
                sb.Append($"{ingredient.ReadableAmount()} {ingredient.Name}\n");
            }
            sb.Append("\n");
            sb.Append($"All {Steps.Length}  of the recipe's steps:\n");
            for (int i = 0; i < Steps.Length; i++)
            {
                sb.Append($"Step #{i + 1} {Steps[i]}\n");
            }
            sb.Append("\n");
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