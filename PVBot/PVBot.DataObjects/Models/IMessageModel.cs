using System;

namespace PVBot.DataObjects.Models
{
    public interface IMessageModel
    {
        bool IsUser { get; set; }
        Guid Id { get; set; }
        string From { get; set; }
        string To { get; set; }
        DateTime Date { get; set; }
        string UserImage { get; set; }
        string Text { get; set; }
        string ImagePath { get; set; }
        string AudioPath { get; set; }
        string AtachedFilePath { get; set; }
        MessageStates State { get; set; }
        MessageTypes Type { get; set; }
    }
}