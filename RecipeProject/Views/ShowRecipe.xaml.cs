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
    /// Interaction logic for ShowRecipe.xaml
    /// </summary>
    public partial class ShowRecipe : Window
    {
        public ShowRecipe(Recipe recipe)
        {
            InitializeComponent();
            this.DataContext = new ShowRecipeViewModel(recipe);
        }
    }
}
