using System.Threading.Tasks;
using ParagonIdTest.Models;
using ParagonIdTest.Views;
using Prism.Commands;
using Prism.Navigation;

namespace ParagonIdTest.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand BeginOrderCommand { get; set; }

        public DelegateCommand SeeStatusOfOrdersCommand { get; set; }

        public DelegateCommand GoToSettingsCommand { get; set; }


        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            BeginOrderCommand = new DelegateCommand(async () => await BeginOrder());
             

            SeeStatusOfOrdersCommand = new DelegateCommand(async () =>
                await NavigationService.NavigateAsync(nameof(OrderSummary)));

            GoToSettingsCommand = new DelegateCommand(async () =>
                await NavigationService.NavigateAsync(nameof(Settings)));
        }

        public async Task BeginOrder()
        {
            State.CurrentPizza = new Pizza();
            await NavigationService.NavigateAsync(nameof(PizzaInitialDetails));
        }
    }
}