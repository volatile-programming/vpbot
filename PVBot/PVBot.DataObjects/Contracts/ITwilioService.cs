using System.Collections.Generic;
using PVBot.DataObjects.Models;

namespace PVBot.DataObjects.Contracts
{
    public interface ITwilioService
    {
        void SendMessage(Message message);
        Message ResiveMessage();
        List<Message> GetMessages();
    }
}
