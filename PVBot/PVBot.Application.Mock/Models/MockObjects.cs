using System;
using System.Collections.Generic;
using PVBot.DataObjects.Models;

namespace PVBot.Application.Mock.Models
{
    public static class MockObjects
    {
        public static Tokens Tokens => new Tokens
        {
            AccessToken = "I HAVE AN AT",
            RefreshToken = "I HAVE A RT"
        };

        public static User User => new User
        {
            Email = "anonimous@unknown.xxx",
            UserName = "anonimous",
            ImagePath = "no_image.png"
        };

        public static TextMessage Message => new TextMessage
        {
            IsUser = true,
            From = "Me",
            To = "Chatbot",
            Date = DateTime.Now,
            Type = MessageTypes.Text,
            State = MessageStates.UserFirtsState,
            Text = "Tell me a joke"
        };

        public static List<Message> Messages =>
            new List<Message>
            {
                new TextMessage
                {
                    Text = "Hello!, I'm PVBot.",
                    IsUser = false,
                    UserImage = "icon_white",
                    Date = DateTime.Now,
                    State = MessageStates.ChatbotOnlyState
                },
                new TextMessage
                {
                    Text = "Hi!, PVBot",
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
                    Text = "Tanks, PVBot",
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
    }
}
