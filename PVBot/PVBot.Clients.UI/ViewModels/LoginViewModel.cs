using Prism.Commands;
using Prism.Navigation;
using PVBot.Application.Commands;
using PVBot.DataObjects.Contracts;

namespace PVBot.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public DelegateCommand NavigateToChatView { get; set; }

        public LoginViewModel(INavigationService navigationService, 
            ICommandFactory commandFactory,
            IQueryFactory queryFactory) 
            : base(navigationService)
        {
            Title = "Login Page";

            NavigateToChatView = commandFactory.MakeCommand<LoginCommand, DelegateCommand>();
        }

    }
}
