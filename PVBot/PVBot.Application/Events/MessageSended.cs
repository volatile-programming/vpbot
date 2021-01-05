using Prism.Events;
using PVBot.DataObjects.Models;

namespace PVBot.Application.Events
{
    public class MessageSended : PubSubEvent<IMessageModel> { }
}
