/// <summary>
/// Name: Sky Martin
/// Student: ST10286905
/// Module: PROG6221
/// References: https://www.youtube.com/watch?v=4v8PobcZpqM
///             https://stackoverflow.com/a/35249141
/// </summary>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Windows.Input;
using System.Xml.Linq;
using RecipeProject.Commands;
using RecipeProject.Models;
using RecipeProject.Views;
using static RecipeProject.Models.Volume;

namespace RecipeProject.ViewModels
{
    class CreateRecipeViewModel : INotifyPropertyChanged
    {
        public class AddIngredientViewModel
        {
            public string Name { get; set; }
            public string UnitName { get; set; } = VolumeUnits.First();
            public float Quantity { get; set; }
            public float Calories { get; set; }
            public string FoodGroup { get; set; }

            public static List<string> VolumeUnits { get; } =
                Enum.GetNames(typeof(Volume.Unit)).Where(name => name != "Unknown").ToList();

            public Ingredient Finish() =>
                new Ingredient(
                    Name,
                    (Volume.Unit)Enum.Parse(typeof(Volume.Unit), UnitName),
                    Quantity,
                    Calories,
                    FoodGroup
                );
        }

        public ICommand AddIngredientCommand { get; set; }
        public ICommand AddStepCommand { get; set; }
        public ICommand SaveRecipeCommand { get; set; }
        public Recipe Recipe { get; set; }
        public string RecipeName
        {
            get => Recipe.Name;
            set
            {
                Recipe.Name = value;
                OnPropertyChanged(nameof(RecipeName));
            }
        }
        public AddIngredientViewModel AddIngredient { get; set; }
        public string Step { get; set; }

        public CreateRecipeViewModel()
        {
            Recipe = new Recipe();

            AddIngredient = new AddIngredientViewModel();
            AddIngredientCommand = new RelayCommand(
                (_) =>
                {
                    Recipe.AddIngredient(AddIngredient.Finish());
                    AddIngredient = new AddIngredientViewModel();
                    OnPropertyChanged(nameof(AddIngredient));
                },
                (_) => true
            );

            AddStepCommand = new RelayCommand(
                (_) =>
                {
                    Recipe.AddStep(Step);
                    Step = "";
                    OnPropertyChanged(nameof(Step));
                },
                (_) => true
            );

            SaveRecipeCommand = new RelayCommand(
                (_) => RecipeManager.AddRecipe(Recipe),
                (_) => true
            );
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
