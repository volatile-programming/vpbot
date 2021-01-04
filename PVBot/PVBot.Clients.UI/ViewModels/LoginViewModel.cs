using System;

using Prism.Commands;
using Prism.Navigation;
using Prism.Services.Dialogs;

using PVBot.Application.Commands;
using PVBot.Clients.Portable.Extensions;
using PVBot.Clients.UI.Commands;
using PVBot.DataObjects.Contracts.Core;
using PVBot.Clients.UI.ViewModels;
using PVBot.DataObjects.Contracts.Factories;

namespace PVBot.ViewModels
{

    public class LoginViewModel : ViewModelBase, IProcessAware
    {
        private readonly IApplicationConfig _appConfig;
        private readonly IDialogService _dialogService;
        private readonly DelegateCommand<IProcessAware> _authoriseUserCommand;

        public LoginViewModel(INavigationService navigationService,
            ICommandFactory commandFactory,
            IDialogService dialogService,
            IApplicationConfig appConfig)
            : base(navigationService)
        {
            _dialogService = dialogService;
            _appConfig = appConfig;
            _authoriseUserCommand = commandFactory
                .MakeDelegateWithParameter<AuthoriseUserCommand, IProcessAware>();

            Title = "Login Page";
            IsLoading = true;

            NavitateCommand = commandFactory.MakeDelegateCommand<NavigateToChatCommand>();
        }

        public DelegateCommand NavitateCommand { get; }

        public bool IsLoading { get; set; }

        private void ValidateSection()
        {

            if (string.IsNullOrWhiteSpace(_appConfig.UserAccessToken))
                IsLoading = false;
            else
                _authoriseUserCommand.Execute(this);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            ValidateSection();
        }

        public Action<string> ErrorCallBack => OnAuthenticationCompleted;

        public void OnAuthenticationCompleted(string errorMessage)
        {
            if (string.IsNullOrEmpty(errorMessage))
            {
                IsLoading = true;
                NavigationService.NavigateAsync("/ChatView");
            }
            else
            {
                IsLoading = false;
                _dialogService.ShowDialogAsync(errorMessage);
            }
        }
    }
}
