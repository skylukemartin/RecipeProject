/// <summary>
/// Name: Sky Martin
/// Student: ST10286905
/// Module: PROG6221
/// References: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=netframework-4.8
///             https://stackoverflow.com/a/355977
/// </summary>

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RecipeProject.Models
{
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
    /// <summary>
    /// This class represents a recipe, including its name, ingredients, steps, total calories, and scale.
    /// </summary>
    public class Recipe : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public ObservableCollection<string> Steps { get; set; }

        public delegate void CalorieUpdate(float newCals, float prevCals);
        public CalorieUpdate OnCalorieUpdate { get; set; }
        float _calories = 0;
        public float Calories
        {
            get
            {
                if (_calories <= 0 && Ingredients.Count > 0)
                    _calories = Ingredients.Select(ingr => ingr.Calories).Sum();
                return _calories;
            }
            set
            {
                var newCals =
                    value >= 0 || Ingredients.Count == 0
                        ? value
                        : Ingredients.Select(ingr => ingr.Calories).Sum();
                if (OnCalorieUpdate != null)
                    OnCalorieUpdate(newCals, _calories);
                _calories = newCals;
            }
        }

        public delegate void ScaleUpdate(float scale);
        public ScaleUpdate OnScaleUpdate { get; set; }
        float _scale = 1;

        public event PropertyChangedEventHandler PropertyChanged;

        public float Scale
        {
            get => _scale;
            set
            {
                if (OnScaleUpdate != null)
                    OnScaleUpdate(value);
                _scale = value;
            }
        }

        public string PrimaryFoodGroup
        {
            get =>
                Ingredients
                    .Select(ingr => ingr.FoodGroup)
                    .GroupBy(fgr => fgr)
                    .OrderByDescending(fgr => fgr.Count())
                    .Select(fgr => fgr.Key)
                    .First();
        }

        public Recipe()
        {
            Ingredients = new ObservableCollection<Ingredient>();
            Steps = new ObservableCollection<string>();
            OnScaleUpdate = InvalidateCalories; // Force recalc of calories on scale update
        }

        void InvalidateCalories(float _) => Calories = -1;

        public Recipe(string name)
            : this()
        {
            Name = name;
        }

        public Recipe(string name, List<Ingredient> ingredients, List<string> steps)
            : this(name)
        {
            ingredients.ForEach(ingr => AddIngredient(ingr));
            steps.ForEach(step => AddStep(step));
        }

        public ObservableCollection<Ingredient> GetIngredients() => Ingredients;

        public void AddIngredient(Ingredient ingredient)
        {
            OnScaleUpdate = ingredient.UpdateScale + OnScaleUpdate;
            Calories += ingredient.Calories;
            Ingredients.Add(ingredient);
        }

        public void RemoveIngredient(Ingredient ingredient)
        {
            OnScaleUpdate -= ingredient.UpdateScale;
            Calories -= ingredient.Calories;
            Ingredients.Remove(ingredient);
        }

        public void UpdateIngredient(Ingredient updated)
        {
            var original = Ingredients.First(ingr => ingr.Name == updated.Name);
            if (original != null)
            {
                RemoveIngredient(original);
                AddIngredient(updated);
            }
        }

        public ObservableCollection<string> GetSteps() => Steps;

        public void AddStep(string step) => Steps.Add(step);

        public void RemoveStep(string step) => Steps.Remove(step);
    }
}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~FILE END~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
