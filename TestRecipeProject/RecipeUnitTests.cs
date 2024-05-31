using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeProject.Classes;
using static RecipeProject.Classes.Recipe;

namespace TestRecipeProject
{
    [TestClass]
    public class RecipeUnitTests
    {
        [TestMethod]
        public void TestMethod1() { }
    }

    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void TestCalorieCalculation_SingleIngredient()
        {
            var recipe = new Recipe("Test Recipe");
            var ingredient = new Ingredient(
                "Apple",
                UnitHelper.Units.Milliliter,
                100,
                50,
                Ingredient.FoodGroups[0]
            );
            recipe.AddIngredient(ingredient);

            var calories = recipe.Calories;

            // Assert
            Assert.AreEqual(50, calories);
        }

        [TestMethod]
        public void TestCalorieCalculation_MultipleIngredients()
        {
            var recipe = new Recipe("Test Recipe");
            var ingredient1 = new Ingredient(
                "Apple",
                UnitHelper.Units.Milliliter,
                100,
                50,
                Ingredient.FoodGroups[0]
            );
            var ingredient2 = new Ingredient(
                "Apple",
                UnitHelper.Units.Milliliter,
                200,
                75,
                Ingredient.FoodGroups[0]
            );
            recipe.AddIngredient(ingredient1);
            recipe.AddIngredient(ingredient2);

            var calories = recipe.Calories;

            // Assert
            Assert.AreEqual(125, calories);
        }

        [TestMethod]
        public void TestCalorieCalculation_Scaling()
        {
            var recipe = new Recipe("Test Recipe");
            var ingredient = new Ingredient(
                "Apple",
                UnitHelper.Units.Milliliter,
                100,
                50,
                Ingredient.FoodGroups[0]
            );
            recipe.AddIngredient(ingredient);

            recipe.ScaleIngredients(2);
            var calories = recipe.Calories;

            // Assert
            Assert.AreEqual(100, calories);
        }

        [TestMethod]
        public void TestCalorieCalculation_ResetScale()
        {
            var recipe = new Recipe("Test Recipe");
            var ingredient = new Ingredient(
                "Apple",
                UnitHelper.Units.Milliliter,
                100,
                50,
                Ingredient.FoodGroups[0]
            );
            recipe.AddIngredient(ingredient);
            recipe.ScaleIngredients(2);

            recipe.ResetIngredientScales();
            var calories = recipe.Calories;

            // Assert
            Assert.AreEqual(50, calories);
        }

        [TestMethod]
        public void TestCalorieCalculation_Notification()
        {
            var recipe = new Recipe("Test Recipe");
            var ingredient = new Ingredient(
                "Apple",
                UnitHelper.Units.Milliliter,
                100,
                50,
                Ingredient.FoodGroups[0]
            );
            recipe.AddIngredient(ingredient);
            bool notified = false;
            recipe.OnCalorieUpdate = (nVal, oVal) =>
            {
                if (JustSurpassedMin(nVal, oVal, 300))
                    notified = true;
            };

            recipe.Calories += 250; // Should now be 300, which is not > 300
            // Assert
            Assert.IsFalse(notified);

            recipe.Calories += 1;
            // Assert
            Assert.IsTrue(notified);
        }

        [TestMethod]
        public void TestCalorieCalculation_JustSurpassedMin()
        {
            var recipe = new Recipe("Test Recipe");
            var ingredient = new Ingredient(
                "Apple",
                UnitHelper.Units.Milliliter,
                100,
                50,
                Ingredient.FoodGroups[0]
            );
            recipe.AddIngredient(ingredient);
            bool notified = false;
            recipe.OnCalorieUpdate += (nVal, oVal) =>
            {
                if (JustSurpassedMin(nVal, oVal, 300))
                    notified = true;
            };

            recipe.Calories = 299; // just below min
            // Assert
            Assert.IsFalse(notified);
            recipe.Calories = 301; // just above min
            // Assert
            Assert.IsTrue(notified);
        }
    }
}
