using System;

namespace PVBot.DataObjects.Models
{
    public class User
    {
        public User(string username, string image)
        {
            UserName = username;
            Image = image;
        }

        public string UserName { get; }
        public string Image { get; }
    }
}