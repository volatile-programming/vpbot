using Ardalis.GuardClauses;
using Prism.Commands;
using Prism.Navigation;

using PVBot.Application.Commands;
using PVBot.Application.Repositories;
using PVBot.Clients.Portable.Extensions;
using PVBot.Clients.UI.ViewModels;
using PVBot.DataObjects.Contracts.Core;
using PVBot.DataObjects.Contracts.Factories;
using PVBot.DataObjects.Models;

namespace PVBot.ViewModels
{
    public class ChatViewModel : ViewModelBase
    {
        public ChatViewModel(INavigationService navigationService,
            IRepositoryFactory repositoryFactory,
            ICommandFactory commandFactory,
            IQueryFactory queryFactory,
            MessageViewModel model)
            : base(navigationService)
        {
            Guard.Against.Null(navigationService, nameof(navigationService));
            Guard.Against.Null(repositoryFactory, nameof(repositoryFactory));
            Guard.Against.Null(commandFactory, nameof(commandFactory));
            Guard.Against.Null(queryFactory, nameof(queryFactory));
            Guard.Against.Null(model, nameof(model));

            Model = model;
            Messages = repositoryFactory.MakeRepository<MessagesRepository>();
            SendMessage = commandFactory.MakeDelegateWithParmeter<SendMessageCommand, Message>();

            Title = "Chat Page";
            GotoOptions = new DelegateCommand(GotoOptionsCommand);
        }

        public (MessageTypes, object) MessageType => (Model.Type, Model);
        public MessageViewModel Model { get; }
        public DelegateCommand<Message> SendMessage { get; }
        public DelegateCommand GotoOptions { get; }
        public DelegateCommand GotoInformation { get; }
        public IRepository<Message> Messages { get; }

        private void GotoOptionsCommand()
        {
        }
    }
}
