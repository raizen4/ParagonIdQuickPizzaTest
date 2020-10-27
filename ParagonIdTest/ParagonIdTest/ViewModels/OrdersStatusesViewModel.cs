using Prism.Commands;
using System.Collections.ObjectModel;
using ParagonIdTest.Models;
using ParagonIdTest.Views;
using Prism.Navigation;

namespace ParagonIdTest.ViewModels
{
    public class OrdersStatusesViewModel : ViewModelBase
    {
        public DelegateCommand GoToMainMenuCommand { get; set; }

        public ObservableCollection<Pizza> ListOfOrders { get; set; }

        public OrdersStatusesViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            ListOfOrders = new ObservableCollection<Pizza>(State.AllOrders);
            GoToMainMenuCommand =
                new DelegateCommand(async () => await NavigationService.NavigateAsync(nameof(MainPage)));
        }
    }
}