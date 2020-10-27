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
                await NavigationService.NavigateAsync(nameof(OrdersStatuses)));

            GoToSettingsCommand = new DelegateCommand(async () =>
                await NavigationService.NavigateAsync(nameof(Settings)));
        }

        public async Task BeginOrder()
        {
            State.CurrentPizza = new Pizza
            {
                Id = Helpers.RandomString(),
                TimeToBake = State.UserOverrideTimeToBake == 0
                    ? Constants
                        .DefaultBakeTimeInSeconds
                    : State.UserOverrideTimeToBake
            };
            await NavigationService.NavigateAsync(nameof(PizzaInitialDetails));
        }
    }
}