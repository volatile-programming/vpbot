using System;

using Prism.Commands;
using Prism.Navigation;
using Prism.Services.Dialogs;

using VPBot.Application.Commands;
using VPBot.Clients.Portable.Extensions;
using VPBot.DataObjects.Contracts.Core;
using VPBot.DataObjects.Contracts.Factories;

namespace VPBot.Clients.UI.Commands
{
    public class NavigateToChatCommand : ICommand
    {
        private readonly DelegateCommand<Action<string>> _authenticateUser;
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;

        public NavigateToChatCommand(INavigationService navigationService,
            ICommandFactory commandFactory,
            IDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            _authenticateUser = commandFactory
                .MakeDelegateWithParameter<AuthenticateUserCommand, Action<string>>();
        }


        public void Execute()
        {
            _authenticateUser.Execute(Completed);
        }

        private void Completed(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                _navigationService.NavigateAsync("/ChatView");
            else
                _dialogService.ShowDialogAsync(errorMessage);

        }
    }
}
