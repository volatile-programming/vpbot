using Prism.Navigation;

namespace PVBot.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Login Page";
        }
    }
}
