using System;
using System.Collections.Generic;
using PVBot.DataObjects.Contracts;
using PVBot.DataObjects.Models;

namespace PVBot.Application.Mock.Services
{
    public class TwilioService : ITwilioService
    {
        public List<Message> GetMessages() =>
            new List<Message> {
                new Message("Me", "Pvbot", "Hello", DateTime.Now),
                new Message("Pvbot", "Me", "Hi!", DateTime.Now)
            };

        public Message ResiveMessage() =>
                new Message("Pvbot", "Me", "Hi!", DateTime.Now);

        public void SendMessage(Message message)
        {
            string format = "Message sended:\n From:{0}\nTo:{1}\nMessage:{2}\nDate:{3}";

            Console.WriteLine(format,
                message.From,
                message.To,
                message.Text,
                message.Date);
        }
    }
}
