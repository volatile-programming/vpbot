using System;
using VPBot.DataObjects.Base;

namespace VPBot.DataObjects.Models
{

    public abstract class Message : BaseEntity
    {
        public bool IsUser { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string UserImage { get; set; }
        public DateTime Date { get; set; }
        public MessageTypes Type { get; set; }
        public MessageStates State { get; set; }
    }
}
