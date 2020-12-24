using Ardalis.GuardClauses;
using PVBot.DataObjects.Contracts;
using PVBot.DataObjects.Models;

namespace PVBot.Application.Commands
{
    public class SendMessageCommand : ICommand<Message>
    {
        private readonly ITwilioService _twilioService;

        public SendMessageCommand(ITwilioService twilioService)
        {
            _twilioService = twilioService;
        }

        public void Execute(Message message)
        {
            Guard.Against.Null(message, nameof(message));

            _twilioService.SendMessage(message);
        }
    }
}
