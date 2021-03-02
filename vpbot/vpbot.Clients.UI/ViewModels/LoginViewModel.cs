using System;

using Prism.Commands;
using Prism.Navigation;
using Prism.Services.Dialogs;

using VPBot.Application.Commands;
using VPBot.Clients.Portable.Extensions;
using VPBot.Clients.UI.Commands;
using VPBot.DataObjects.Contracts.Core;
using VPBot.Clients.UI.ViewModels;
using VPBot.DataObjects.Contracts.Factories;

namespace VPBot.ViewModels
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
