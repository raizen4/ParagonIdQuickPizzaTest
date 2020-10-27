using System;
using System.Threading.Tasks;
using ParagonIdTest.Views;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace ParagonIdTest.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public int NewBakingTime { get; set; }

        private IPageDialogService _dialogService;
        public DelegateCommand ApplySettingsCommand { get; set; }

        public DelegateCommand GoToMainPageCommand { get; set; }

        public SettingsViewModel(IPageDialogService dialogService,INavigationService navigationService)
            : base(navigationService)
        {
            _dialogService = dialogService;
            NewBakingTime = 10;
            GoToMainPageCommand =
                new DelegateCommand(async () => await NavigationService.NavigateAsync(nameof(MainPage)));
            ApplySettingsCommand = new DelegateCommand(async () => await ApplySettings(NewBakingTime));
        }

        public async Task ApplySettings(int newBakeTime)
        {
            if (newBakeTime < 10)
            {
                await _dialogService.DisplayAlertAsync("Error",
                    $"The baking time must be at least 10 seconds", "OK");
            }
            else
            {
                State.UserOverrideTimeToBake = newBakeTime;

                await NavigationService.NavigateAsync(nameof(MainPage));
            }
           
        }
    }
}