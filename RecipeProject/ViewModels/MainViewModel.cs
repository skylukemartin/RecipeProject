/// <summary>
/// Name: Sky Martin
/// Student: ST10286905
/// Module: PROG6221
/// References: https://www.youtube.com/watch?v=4v8PobcZpqM
/// </summary>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using RecipeProject.Commands;
using RecipeProject.Models;
using RecipeProject.Views;

namespace RecipeProject.ViewModels
{
    /// <summary>
    /// ViewModel for the main window of the recipe application.
    /// Manages the list of recipes, filtering, and navigation to other windows.
    /// </summary>
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
    class MainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the full collection of recipes.
        /// </summary>
        public ObservableCollection<Recipe> Recipes { get; set; }

        /// <summary>
        /// Gets or sets the filtered collection of recipes based on user-defined criteria.
        /// </summary>
        public ObservableCollection<Recipe> FilteredRecipes { get; set; }

        /// <summary>
        /// Command to execute the recipe filtering.
        /// </summary>
        public ICommand FilterRecipesCommand { get; set; }

        /// <summary>
        /// Command to show the Add Recipe window.
        /// </summary>
        public ICommand ShowAddRecipeWindowCommand { get; set; }

        /// <summary>
        /// Command to show the Selected Recipe window.
        /// </summary>
        public ICommand ShowSelectedRecipeWindowCommand { get; set; } // not working

        private string _containsIngredient;

        /// <summary>
        /// Gets or sets the ingredient filter string.
        /// </summary>
        public string ContainsIngredient
        {
            get => _containsIngredient;
            set
            {
                _containsIngredient = value;
                OnPropertyChanged(nameof(ContainsIngredient));
            }
        }

        private string _onlyFoodGroup;

        /// <summary>
        /// Gets or sets the food group filter string.
        /// </summary>
        public string OnlyFoodGroup
        {
            get => _onlyFoodGroup;
            set
            {
                _onlyFoodGroup = value;
                OnPropertyChanged(nameof(OnlyFoodGroup));
            }
        }

        private int _maxCalories;

        /// <summary>
        /// Gets or sets the maximum calories filter value.
        /// </summary>
        public int MaxCalories
        {
            get => _maxCalories;
            set
            {
                _maxCalories = value;
                OnPropertyChanged(nameof(MaxCalories));
            }
        }

        private Recipe _selectedRecipe;

        /// <summary>
        /// Gets or sets the currently selected recipe.
        /// </summary>
        public Recipe SelectedRecipe
        {
            get => _selectedRecipe;
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged(nameof(SelectedRecipe));
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// Sets up initial data and commands.
        /// </summary>
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        public MainViewModel()
        {
            Recipes = RecipeManager.GetRecipes();
            RecipeManager.RecipesChanged += RecipeManager_RecipesChanged;

            FilteredRecipes = new ObservableCollection<Recipe>(Recipes);
            FilterRecipesCommand = new RelayCommand(ExecuteFilterRecipes, (_) => true);
            ShowAddRecipeWindowCommand = new RelayCommand(
                (_) => new CreateRecipe().Show(),
                (_) => true
            );
            ShowSelectedRecipeWindowCommand = new RelayCommand(
                (_) =>
                {
                    if (SelectedRecipe != null)
                        new ShowRecipe(SelectedRecipe).Show();
                },
                (_) => true
            );
        }

        /// <summary>
        /// Executes the recipe filtering based on user-defined criteria.
        /// </summary>
        /// <param name="_">Unused parameter.</param>
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        void ExecuteFilterRecipes(object _)
        {
            var filteredRecipes = Recipes.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(ContainsIngredient))
            {
                filteredRecipes = filteredRecipes.Where(r =>
                    r.Ingredients.Any(i => i.Name.ToLower().Contains(ContainsIngredient.ToLower()))
                );
            }

            if (!string.IsNullOrWhiteSpace(OnlyFoodGroup))
            {
                filteredRecipes = filteredRecipes.Where(r =>
                    r.PrimaryFoodGroup.ToLower() == OnlyFoodGroup.ToLower()
                );
            }

            if (MaxCalories > 0)
            {
                filteredRecipes = filteredRecipes.Where(r => r.Calories <= MaxCalories);
            }

            FilteredRecipes.Clear();
            foreach (var recipe in filteredRecipes)
            {
                FilteredRecipes.Add(recipe);
            }
        }

        /// <summary>
        /// Handles the RecipesChanged event from RecipeManager.
        /// Refreshes the recipe list and reapplies the filter.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        private void RecipeManager_RecipesChanged(object sender, EventArgs e)
        {
            Recipes = RecipeManager.GetRecipes(); // Refresh the Recipes collection
            ExecuteFilterRecipes(null); // Reset the filter
        }

        /// <summary>
        /// Unsubscribes from the RecipesChanged event.
        /// </summary>
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        public void Dispose() => RecipeManager.RecipesChanged -= RecipeManager_RecipesChanged;

        /// <summary>
        /// Event for property change notifications.
        /// </summary>
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">Name of the property that changed.</param>
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~FILE END~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
