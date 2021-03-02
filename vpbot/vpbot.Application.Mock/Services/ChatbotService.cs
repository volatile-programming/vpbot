using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using VPBot.Application.Mock.Models;
using VPBot.DataObjects.Contracts.Services;
using VPBot.DataObjects.Models;

namespace VPBot.Application.Mock.Services
{
    public class ChatbotService : IChatbotService
    {
        public bool HasUnreadMessages() => true;

        public Task<bool> HasUnreadMessagesAsync() => Task.FromResult(HasUnreadMessages());

        public List<Message> GetMessages() => MockObjects.Messages;

        public Task<List<Message>> GetMessagesAsync() => Task.FromResult(GetMessages());

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

        public Task SendMessageAsync(Message message) => Task.Run(() => SendMessage(message));

        public Message ResiveMessage() => MockObjects.Message;

        public Task<Message> ResiveMessageAsync() => Task.FromResult(ResiveMessage());
    }
}
