using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ParagonIdTest.Interfaces;
using ParagonIdTest.Models;
using ParagonIdTest.Views;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace ParagonIdTest.ViewModels
{
    public class PizzaToppingsViewModel : ViewModelBase
    {
        private ObservableCollection<Topping> _selectedToppings;

        public IPageDialogService _dialogService;
        public ObservableCollection<Topping> SelectedToppings
        {
            get => _selectedToppings;
            set => SetProperty(ref _selectedToppings, value);
    }

        public DelegateCommand GoToSummaryCommand { get; set; }
        public DelegateCommand GoToInitialDetails { get; set; }

        public List<Topping> AvailableToppings { get; set; }


        public PizzaToppingsViewModel(IPageDialogService dialogService, INavigationService navigationService, IFacade facade)
            : base(navigationService)
        {
            AvailableToppings = facade.GetAvailableToppings();
            _dialogService = dialogService;
            
            SelectedToppings = State.CurrentPizza.Toppings?.Count > 0
                ? new ObservableCollection<Topping>(State.CurrentPizza.Toppings) 
                : new ObservableCollection<Topping>();
            
            GoToSummaryCommand = new DelegateCommand(async () => await NavigateToSummary());
            GoToInitialDetails = new DelegateCommand(async () => await NavigationService.NavigateAsync(nameof(PizzaInitialDetails)));
        }

        public void SelectionModified(IEnumerable<object> newSelection)
        {

            SelectedToppings = new ObservableCollection<Topping>(newSelection.Select(obj=> obj as Topping));
        }

        public async Task NavigateToSummary()
        {
            if (SelectedToppings.Count == 0)
            {
                await _dialogService.DisplayAlertAsync("Warning",
                    "You Must select at least one topping to be able to continue", "OK");
            }
            else
            {
                State.CurrentPizza.Toppings = SelectedToppings.ToList();

                await NavigationService.NavigateAsync(nameof(OrderSummary));
            }
        }
    }
}