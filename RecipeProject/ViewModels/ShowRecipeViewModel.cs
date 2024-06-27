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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RecipeProject.Commands;
using RecipeProject.Models;

namespace RecipeProject.ViewModels
{
    /// <summary>
    /// ViewModel for displaying and interacting with a single recipe.
    /// </summary>
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
    class ShowRecipeViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Represents a step in a recipe that can be ticked off.
        /// </summary>
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        public class TickableStep : INotifyPropertyChanged
        {
            /// <summary>
            /// Command to toggle the ticked state of the step.
            /// </summary>
            public ICommand ToggleTickCommand { get; set; }

            /// <summary>
            /// The number of the step in the recipe.
            /// </summary>
            public int Number { get; }

            /// <summary>
            /// The description of the step.
            /// </summary>
            public string Description { get; }

            private bool _ticked;

            /// <summary>
            /// Gets or sets whether the step has been ticked off.
            /// </summary>
            public bool Ticked
            {
                get => _ticked;
                set
                {
                    _ticked = value;
                    OnPropertyChanged(nameof(Ticked));
                }
            }

            /// <summary>
            /// Initializes a new instance of the TickableStep class.
            /// </summary>
            /// <param name="number">The step number.</param>
            /// <param name="description">The step description.</param>
            /// <param name="isTicked">Initial ticked state.</param>
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
            public TickableStep(int number, string description, bool isTicked = false)
            {
                Number = number;
                Description = description;
                Ticked = isTicked;
                ToggleTickCommand = new RelayCommand(
                    (_) =>
                    {
                        Ticked = !Ticked;
                    },
                    (_) => true
                );
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName) =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // <summary>
        /// Command to scale the recipe.
        /// </summary>
        public ICommand ScaleRecipeCommand { get; set; }

        /// <summary>
        /// The recipe being displayed.
        /// </summary>
        public Recipe Recipe { get; set; }

        private float _scale;

        /// <summary>
        /// Gets or sets the scale factor for the recipe.
        /// </summary>
        public float Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                OnPropertyChanged(nameof(Scale));
            }
        }

        /// <summary>
        /// The ingredients of the recipe.
        /// </summary>
        public ObservableCollection<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// The steps of the recipe, represented as TickableSteps.
        /// </summary>
        public ObservableCollection<TickableStep> Steps { get; set; }

        /// <summary>
        /// Initializes a new instance of the ShowRecipeViewModel class.
        /// </summary>
        /// <param name="recipe">The recipe to be displayed.</param>
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        public ShowRecipeViewModel(Recipe recipe)
        {
            Recipe = recipe;
            Scale = Recipe.Scale;
            Ingredients = Recipe.Ingredients;
            Steps = new ObservableCollection<TickableStep>();
            for (int i = 0; i < Recipe.Steps.Count; i++)
                Steps.Add(new TickableStep(i + 1, Recipe.Steps[i]));

            ScaleRecipeCommand = new RelayCommand(
                (_) =>
                {
                    Recipe.Scale = Scale;
                    OnPropertyChanged(nameof(Recipe));
                    Ingredients = null;
                    OnPropertyChanged(nameof(Ingredients));
                    Ingredients = Recipe.Ingredients;
                    OnPropertyChanged(nameof(Ingredients));
                },
                (_) => true
            );
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
