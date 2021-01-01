using System;
using System.Collections.Generic;
using System.Text;
using PVBot.DataObjects.Contracts.Core;

namespace PVBot.DataObjects.Base
{
    public class BaseEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
