/// <summary>
/// Name: Sky Martin
/// Student: ST10286905
/// Module: PROG6221
/// References: https://www.youtube.com/watch?v=4v8PobcZpqM
///             https://stackoverflow.com/a/61637314
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RecipeProject.Models;
using RecipeProject.ViewModels;

namespace RecipeProject.Views
{
    /// <summary>
    /// Interaction logic for CreateRecipe.xaml
    /// </summary>
    public partial class CreateRecipe : Window
    {
        public CreateRecipe()
        {
            InitializeComponent();
            this.DataContext = new CreateRecipeViewModel();
        }
    }
}
