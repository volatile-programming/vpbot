using System;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services.Dialogs;
using PVBot.Application.Commands;
using PVBot.DataObjects.Contracts.Factories;
using PVBot.DataObjects.Extensions;

namespace PVBot.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IDialogService dialogService;

        public LoginViewModel(INavigationService navigationService,
            ICommandFactory commandFactory,
            IDialogService dialogService)
            : base(navigationService)
        {
            Title = "Login Page";

            AuthenticateUser = commandFactory.MakeCommand<AuthenticateUserCommand>();
            LoginCommand = new DelegateCommand(GetUserCredentialsCommand);
            this.dialogService = dialogService;
        }

        public AuthenticateUserCommand AuthenticateUser { get; }
        public DelegateCommand LoginCommand { get; }

        private void GetUserCredentialsCommand() =>
            AuthenticateUser.Execute(new Action<string>(OnLoaginCompleted));

        private void OnLoaginCompleted(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                NavigationService.NavigateAsync("/ChatView");
            else
                OnLoginFailed(errorMessage);
        }

        private void OnLoginFailed(string errorMessage)
        {
            dialogService.ShowDialogAsync(errorMessage);
        }
    }
}
