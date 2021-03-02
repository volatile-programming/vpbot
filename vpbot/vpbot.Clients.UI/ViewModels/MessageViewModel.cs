using System;
using VPBot.DataObjects.Models;

namespace VPBot.Clients.UI.ViewModels
{
    public class MessageViewModel : ViewModelBase, IMessageModel
    {
        public bool IsUser { get; set; }
        public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string UserImage { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public string AudioPath { get; set; }
        public string AtachedFilePath { get; set; }
        public MessageStates State { get; set; }
        public MessageTypes Type { get; set; }
    }
}
