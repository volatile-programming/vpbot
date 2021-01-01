using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PVBot.DataObjects.Contracts.Services;
using PVBot.DataObjects.Models;

namespace PVBot.Application.Mock.Services
{
    public class ChatbotService : IChatbotService
    {
        public bool HasUnreadMessages() => true;

        public Task<bool> HasUnreadMessagesAsync() =>
            Task.FromResult(HasUnreadMessages());

        public List<Message> GetMessages() =>
            new List<Message>
            {
                new TextMessage { Text = "Hello!, I'm PVBot.", IsUser = false, State = MessageStates.ChatbotOnly },
                new TextMessage { Text = "Hi!, PVBot", IsUser = true, State = MessageStates.UserFirts },
                new TextMessage { Text = "Tell me a joke.", IsUser = true, State = MessageStates.UserLast },
                new ImageMessage { Text = "loock at this.", IsUser = false, State = MessageStates.ChatbotOnly },
                new VoiceMessage { AudioPath = "temp/files", IsUser = true, State = MessageStates.UserOnly },
            };

        public Task<List<Message>> GetMessagesAsync() =>
            Task.FromResult(GetMessages());

        public void SendMessage(Message message)
        {
            string format = "Message sended:\nFrom:{0}\nTo:{1}\nDate:{2}\nType:{3}\nIsUser:{4}";

            Console.WriteLine(format,
                message.From,
                message.To,
                message.Date,
                message.Type,
                message.IsUser);
        }

        public Task SendMessageAsync(Message message)
        {
            SendMessage(message);
            return Task.CompletedTask;
        }


        public Message ResiveMessage() => new TextMessage();

        public Task<Message> ResiveMessageAsync() =>
            Task.FromResult(ResiveMessage());
    }
}
