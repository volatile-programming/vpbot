using System;
using PVBot.DataObjects.Base;

namespace PVBot.DataObjects.Models
{
    public enum MessageTypes : byte
    {
        Text,
        Voice,
        Image,
        File
    }

    public enum MessageStates : byte
    {
        ChatbotOnly,
        ChatbotFirts,
        ChatbotMiddle,
        ChatbotLast,
        UserOnly,
        UserFirts,
        UserMiddle,
        UserLast
    }

    public abstract class Message : BaseEntity
    {
        public bool IsUser { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public MessageTypes Type { get; set; }
        public MessageStates State { get; set; }
    }

    public class TextMessage : Message
    {
        public string Text { get; set; }
    }

    public class VoiceMessage : Message
    {
        public string AudioPath { get; set; }
    }

    public class ImageMessage : TextMessage
    {
        public string ImagePath { get; set; }
    }

    public class FileMessage : TextMessage
    {
        public string AtachedFilePath { get; set; }
    }
}
