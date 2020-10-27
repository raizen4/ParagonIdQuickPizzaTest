using Prism.Commands;
using Prism.Navigation;

namespace ParagonIdTest.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public DelegateCommand ApplySettingsCommand { get; set; }

        public DelegateCommand GoToMainPageCommand { get; set; }

        public SettingsViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }
    }
}