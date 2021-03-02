using System.Collections.Generic;
using System.Threading.Tasks;
using VPBot.DataObjects.Models;

namespace VPBot.DataObjects.Contracts.Services
{
    public interface IChatbotService
    {
        bool HasUnreadMessages();
        Task<bool> HasUnreadMessagesAsync();
        List<Message> GetMessages();
        Task<List<Message>> GetMessagesAsync();
        void SendMessage(Message message);
        Task SendMessageAsync(Message message);
        Message ResiveMessage();
        Task<Message> ResiveMessageAsync();
    }
}
