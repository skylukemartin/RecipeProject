using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeProject.Classes;

namespace RecipeProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RecipeHelper recipeHelper = new RecipeHelper();
            recipeHelper.MainMenu();
        }
    }
}
