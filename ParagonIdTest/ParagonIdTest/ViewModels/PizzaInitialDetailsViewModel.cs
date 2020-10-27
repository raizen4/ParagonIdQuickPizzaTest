using Prism.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParagonIdTest.Views;
using Prism.Navigation;

namespace ParagonIdTest.ViewModels
{
    public class PizzaInitialDetailsViewModel : ViewModelBase
    {
        private string _selectedCheese;

        private string _selectedSize;

        private string _selectedCrust;

        public string SelectedSize
        {
            get => _selectedSize;
            set => SetProperty(ref _selectedSize, value);
        }

        public string SelectedCrust
        {
            get => _selectedCrust;
            set => SetProperty(ref _selectedCrust, value);
        }

        public string SelectedCheese
        {
            get => _selectedCheese;
            set => SetProperty(ref _selectedCheese, value);
        }

        public DelegateCommand GoToToppingsCommand { get; set; }

        public DelegateCommand GoToMainMenuCommand { get; set; }

        public List<string> TypesOfCheese { get; set; }

        public List<string> Sizes { get; set; }

        public List<string> CrustTypes { get; set; }

        public PizzaInitialDetailsViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Sizes = new List<string>
            {
                "Small",
                "Medium",
                "Large"
            };

            CrustTypes = new List<string>
            {
                "Pan",
                "Classic",
                "Stuffed With Cheese"
            };

            TypesOfCheese = new List<string>
            {
                "Reduced Fat Cheese",
                "Mozzarella",
                "Blue cheese"
            };

            SelectedCrust = State.CurrentPizza.CrustType != null
                ? State.CurrentPizza.CrustType
                : CrustTypes[0];

            SelectedCheese = State.CurrentPizza.TypeOfCheese != null
                ? State.CurrentPizza.TypeOfCheese
                : TypesOfCheese[0];

            SelectedSize = State.CurrentPizza.Size != null
                ? State.CurrentPizza.Size
                : Sizes[0];

            GoToToppingsCommand =
                new DelegateCommand(async () => await AdvanceToPizzaToppings());

            GoToMainMenuCommand =
                new DelegateCommand(async () => await NavigationService.NavigateAsync(nameof(MainPage)));
        }

        private async Task AdvanceToPizzaToppings()
        {
            State.CurrentPizza.CrustType = SelectedCrust;
            State.CurrentPizza.Size = SelectedSize;
            State.CurrentPizza.TypeOfCheese = SelectedCheese;
            await NavigationService.NavigateAsync(nameof(PizzaToppings));
        }
    }
}