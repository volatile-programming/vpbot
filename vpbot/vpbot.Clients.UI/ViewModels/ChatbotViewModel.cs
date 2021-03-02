using System;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Prism.Events;

using VPBot.Application.Events;
using VPBot.DataObjects.Contracts.Core;
using VPBot.DataObjects.Models;
using VPBot.DataObjects.Properties;

namespace VPBot.Clients.UI.ViewModels
{
    public class ChatbotViewModel : ViewModelBase
    {
        private readonly IRepository<Message> _messages;

        public ChatbotViewModel(IRepository<Message> messages,
            IEventAggregator eventAgregator)
        {
            Guard.Against.Null(messages, nameof(messages));

            _messages = messages;

            eventAgregator.GetEvent<MessageSended>()
                .Subscribe(RespondeMessage, ThreadOption.UIThread);

            IsThinking = false;
        }

        public bool IsThinking { get; set; }

        private async void RespondeMessage(IMessageModel message)
        {
            IsThinking = true;

            await Task.Delay(TimeSpan.FromSeconds(3));

            // TODO: remove on real implementation of chatbot
            var response = new TextMessage
            {
                IsUser = false,
                Id = Guid.NewGuid(),
                From = "Pvbot",
                To = "@Me",
                Text = Resource.PvbotDefaultResponse,
                UserImage = "icon_white",
                Date = DateTime.Now,
                State = MessageStates.ChatbotOnlyState,
                Type = MessageTypes.Text,
            };

            IsThinking = false;

            _messages.Add(response);
        }
    }
}
