using ParagonIdTest.Interfaces;
using ParagonIdTest.Services;
using Prism;
using Prism.Ioc;
using ParagonIdTest.ViewModels;
using ParagonIdTest.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;

namespace ParagonIdTest
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            // Register pages for navigation
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<PizzaToppings, PizzaToppingsViewModel>();
            containerRegistry.RegisterForNavigation<Settings, SettingsViewModel>();
            containerRegistry.RegisterForNavigation<OrderSummary, OrderSummaryViewModel>();
            containerRegistry.RegisterForNavigation<PizzaInitialDetails, PizzaInitialDetailsViewModel>();

            //Register singleton for services.
            containerRegistry.Register<IFacade, Facade>();
            containerRegistry.RegisterForNavigation<OrdersStatuses, OrdersStatusesViewModel>();
        }
    }
}