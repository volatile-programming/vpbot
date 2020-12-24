using System;

namespace PVBot.DataObjects.Models
{
    public class Message
    {
        public Message(string from, string to, string text, DateTime date)
        {
            From = from;
            To = to;
            Text = text;
            Date = date;
        }

        public string From { get; }
        public string To { get; }
        public string Text { get; }
        public DateTime Date { get; }
    }
}
