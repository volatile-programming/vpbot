using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VPBot.DataObjects.Contracts.Services;
using VPBot.DataObjects.Models;

namespace VPBot.Application.Services
{
    public class ChatbotService : IChatbotService
    {
        public bool HasUnreadMessages() => true;

        public Task<bool> HasUnreadMessagesAsync() =>
            Task.FromResult(HasUnreadMessages());

        public List<Message> GetMessages() =>
            new List<Message>
            {
                new TextMessage
                {
                    Text = "Hello!, I'm VPBot.",
                    IsUser = false,
                    UserImage = "icon_white",
                    Date = DateTime.Now,
                    State = MessageStates.ChatbotOnlyState
                },
                new TextMessage
                {
                    Text = "Hi!, VPBot",
                    IsUser = true,
                    UserImage = "pv_icon",
                    Date = DateTime.Now,
                    State = MessageStates.UserFirtsState
                },
                new TextMessage
                {
                    Text = "Tell me a joke.",
                    IsUser = true,
                    UserImage = "pv_icon",
                    Date = DateTime.Now,
                    State = MessageStates.UserLastState
                },
                new TextMessage
                {
                    Text = "I'm so good at sleeping.",
                    IsUser = false,
                    UserImage = "icon_white",
                    Date = DateTime.Now,
                    State = MessageStates.ChatbotFirtsState
                },
                new TextMessage
                {
                    Text = "I can do it with",
                    IsUser = false,
                    UserImage = "icon_white",
                    Date = DateTime.Now,
                    State = MessageStates.ChatbotMiddleState
                },
                new TextMessage
                {
                    Text = "my eyes closed.",
                    IsUser = false,
                    UserImage = "icon_white",
                    Date = DateTime.Now,
                    State = MessageStates.ChatbotLastState
                },
                new TextMessage
                {
                    Text = "jajajajajajaja...",
                    IsUser = true,
                    UserImage = "pv_icon",
                    Date = DateTime.Now,
                    State = MessageStates.UserOnlyState
                },
                new TextMessage
                {
                    Text = "How good it was?",
                    IsUser = false,
                    UserImage = "icon_white",
                    Date = DateTime.Now,
                    State = MessageStates.ChatbotOnlyState
                },
                new TextMessage
                {
                    Text = "Tanks, VPBot",
                    IsUser = true,
                    UserImage = "pv_icon",
                    Date = DateTime.Now,
                    State = MessageStates.UserFirtsState
                },
                new TextMessage
                {
                    Text = "I liked that joke",
                    IsUser = true,
                    UserImage = "pv_icon",
                    Date = DateTime.Now,
                    State = MessageStates.UserMiddleState
                },
                new TextMessage
                {
                    Text = "See you later.",
                    IsUser = true,
                    UserImage = "pv_icon",
                    Date = DateTime.Now,
                    State = MessageStates.UserLastState
                },
                new TextMessage
                {
                    Text = "You are welcome!",
                    IsUser = false,
                    UserImage = "icon_white",
                    Date = DateTime.Now,
                    State = MessageStates.ChatbotOnlyState
                },
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
