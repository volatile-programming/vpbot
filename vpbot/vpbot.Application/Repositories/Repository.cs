using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VPBot.DataObjects.Contracts.Core;

namespace VPBot.Application.Repositories
{
    public class Repository<TEntity> :
        ObservableCollection<TEntity>,
        IRepository<TEntity>
        where TEntity : IEntity<Guid>
    {
        public void AddRange(IEnumerable<TEntity> messages)
        {
            foreach (var message in messages)
                Add(message);
        }
    }
}
