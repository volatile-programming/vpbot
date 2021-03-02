namespace VPBot.DataObjects.Models
{
    public interface IChatBoxModel : IMessageModel
    {
        IMessageModel LastMessage { get; }
        IMessageModel Message { get; }
    }
}