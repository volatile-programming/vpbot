using PVBot.DataObjects.Base;

namespace PVBot.DataObjects.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string ImagePath { get; set; }
    }
}