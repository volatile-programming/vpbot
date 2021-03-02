using System;
using System.Collections.Generic;
using System.Text;
using VPBot.DataObjects.Contracts.Core;

namespace VPBot.DataObjects.Base
{
    public class BaseEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
