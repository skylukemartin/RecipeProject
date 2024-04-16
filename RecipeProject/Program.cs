namespace RecipeProject
{
    using Classes;

    internal class Program
    {
        static void Main(string[] args)
        {
            RecipeHelper recipeHelper = new RecipeHelper();
            recipeHelper.SetDebugRecipe(); // Test with a nice big recipe
            recipeHelper.MainMenu();
        }
    }
}
