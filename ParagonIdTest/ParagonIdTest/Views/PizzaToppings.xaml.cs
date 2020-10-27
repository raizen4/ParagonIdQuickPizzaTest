using System.Collections.Generic;
using System.Linq;
using ParagonIdTest.Models;
using ParagonIdTest.ViewModels;
using Xamarin.Forms;

namespace ParagonIdTest.Views
{
    public partial class PizzaToppings : ContentPage
    {
        private PizzaToppingsViewModel viewModel;

        public PizzaToppings()
        {
            InitializeComponent();
            viewModel = (PizzaToppingsViewModel) BindingContext;
        }

        private void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (viewModel != null)
            {
                
                if (e.CurrentSelection.Count <= 4)
                {
                    viewModel.SelectionModified(e.CurrentSelection.AsEnumerable());
                }
                else
                {
                    ((CollectionView) sender).SelectedItems = e.PreviousSelection.ToList();
                }
            }
          
        }
    }
}