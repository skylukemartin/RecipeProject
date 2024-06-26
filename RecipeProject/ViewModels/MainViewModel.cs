/// <summary>
/// Name: Sky Martin
/// Student: ST10286905
/// Module: PROG6221
/// References: https://www.youtube.com/watch?v=4v8PobcZpqM
/// </summary>

using System.Collections.ObjectModel;
using System.Windows.Input;
using RecipeProject.Commands;
using RecipeProject.Models;
using RecipeProject.Views;

namespace RecipeProject.ViewModels
{
    class MainViewModel
    {
        public ObservableCollection<Recipe> Recipes { get; set; }
        public ICommand ShowWindowCommand { get; set; }

        public MainViewModel()
        {
            Recipes = RecipeManager.GetRecipes();
            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
        }

        private void ShowWindow(object obj) => new AddRecipe().Show();

        private bool CanShowWindow(object obj) => true;
    }
}
