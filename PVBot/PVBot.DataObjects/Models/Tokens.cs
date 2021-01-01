using System;
using System.Collections.Generic;
using System.Text;
using PVBot.DataObjects.Base;

namespace PVBot.DataObjects.Models
{
    public class Tokens : BaseEntity
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
