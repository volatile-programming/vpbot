using Prism.Events;
using VPBot.DataObjects.Models;

namespace VPBot.Application.Events
{
    public class MessageSended : PubSubEvent<IMessageModel> { }
}
