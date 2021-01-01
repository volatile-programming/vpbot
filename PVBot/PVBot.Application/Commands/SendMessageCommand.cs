using Ardalis.GuardClauses;
using PVBot.Application.Repositories;
using PVBot.DataObjects.Contracts.Core;
using PVBot.DataObjects.Contracts.Factories;
using PVBot.DataObjects.Models;

namespace PVBot.Application.Commands
{
    public class SendMessageCommand : ICommand<Message>
    {
        public SendMessageCommand(IRepositoryFactory repositoryFactory)
        {
            Guard.Against.Null(repositoryFactory, nameof(repositoryFactory));

            MessageRepository = repositoryFactory.MakeRepository<MessagesRepository>();
        }

        private IRepository<Message> MessageRepository { get; }

        public void Execute(Message message)
        {
            Guard.Against.Null(message, nameof(message));

            MessageRepository.Add(message);
        }
    }
}
