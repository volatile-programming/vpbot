using System;
using Ardalis.GuardClauses;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services.Dialogs;
using PVBot.Application.Commands;
using PVBot.Application.Queries;
using PVBot.Clients.Portable.Extensions;
using PVBot.Clients.UI.ViewModels;
using PVBot.DataObjects.Contracts.Core;
using PVBot.DataObjects.Contracts.Factories;
using PVBot.DataObjects.Models;
using PVBot.DataObjects.Properties;

namespace PVBot.ViewModels
{
    public class ChatViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly GetMessagesQuery _getMessagesQuery;


        public ChatViewModel(INavigationService navigationService,
            IRepository<Message> messageRepository,
            ChatbotViewModel chatbotViewModel,
            ICommandFactory commandFactory,
            IDialogService dialogService,
            IQueryFactory queryFactory,
            ChatBoxViewModel message)
            : base(navigationService)
        {
            Guard.Against.Null(navigationService, nameof(navigationService));
            Guard.Against.Null(messageRepository, nameof(messageRepository));
            Guard.Against.Null(chatbotViewModel, nameof(chatbotViewModel));
            Guard.Against.Null(commandFactory, nameof(commandFactory));
            Guard.Against.Null(dialogService, nameof(dialogService));
            Guard.Against.Null(queryFactory, nameof(queryFactory));
            Guard.Against.Null(message, nameof(message));

            ChatbotViewModel = chatbotViewModel;
            _dialogService = dialogService;
            Messages = messageRepository;
            ChatBoxViewModel = message;

            Title = "Chat Page";
            SendMessage = commandFactory
                .MakeDelegateWithParameter<SendMessageCommand, IChatBoxModel>();

            GotoOptions = new DelegateCommand(GotoOptionsCommand);
            _getMessagesQuery = queryFactory.MakeQuery<GetMessagesQuery>();
        }

        public ChatbotViewModel ChatbotViewModel { get; }
        public ChatBoxViewModel ChatBoxViewModel { get; }
        public DelegateCommand<IChatBoxModel> SendMessage { get; }


        public DelegateCommand GotoOptions { get; }
        public DelegateCommand GotoInformation { get; }
        public IRepository<Message> Messages { get; }
        public Action<string> ErrorCallBack { get; }

        private async void GotoOptionsCommand()
        {
            await _dialogService.ShowDialogAsync(Resource.WipDialogMessage);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var messages = _getMessagesQuery.Execute();

            Messages.AddRange(messages);
        }
    }
}
