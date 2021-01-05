namespace PVBot.DataObjects.Models
{
    public enum MessageStates : byte
    {
        ChatbotOnlyState,
        ChatbotFirtsState,
        ChatbotMiddleState,
        ChatbotLastState,
        UserOnlyState,
        UserFirtsState,
        UserMiddleState,
        UserLastState
    }
}
