/// <summary>
/// Name: Sky Martin
/// Student: ST10286905
/// Module: PROG6221
/// References: https://www.youtube.com/watch?v=4v8PobcZpqM
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RecipeProject.Models;
using RecipeProject.ViewModels;

namespace RecipeProject.Views
{
    /// <summary>
    /// /// TODO: Fill in
    /// </summary>
    public partial class Main : Window
    {
        private MainViewModel _viewModel;

        /// <summary>
        /// TODO: Fill in
        /// </summary>
        public Main()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            this.DataContext = _viewModel;
        }

        /// <summary>
        /// TODO: Fill in
        /// </summary>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _viewModel.Dispose();
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender.GetType() == typeof(ListBox))
            {
                var listBox = (ListBox)sender;
                if (listBox.SelectedItem.GetType() == typeof(Recipe))
                    new ShowRecipe((Recipe)listBox.SelectedItem).Show();
            }
        }
    }
}
