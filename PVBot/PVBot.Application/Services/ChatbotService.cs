using System.Collections.Generic;
using System.Threading.Tasks;
using PVBot.DataObjects.Contracts.Services;
using PVBot.DataObjects.Models;

namespace PVBot.Application.Services
{
    public class ChatbotService : IChatbotService
    {
        public bool HasUnreadMessages()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> HasUnreadMessagesAsync()
        {
            throw new System.NotImplementedException();
        }

        public List<Message> GetMessages()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Message>> GetMessagesAsync()
        {
            throw new System.NotImplementedException();
        }

        public void SendMessage(Message message)
        {
            throw new System.NotImplementedException();
        }

        public Task SendMessageAsync(Message message)
        {
            throw new System.NotImplementedException();
        }

        public Message ResiveMessage()
        {
            throw new System.NotImplementedException();
        }

        public Task<Message> ResiveMessageAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
