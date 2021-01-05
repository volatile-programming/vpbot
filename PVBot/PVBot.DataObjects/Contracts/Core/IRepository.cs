using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace PVBot.DataObjects.Contracts.Core
{
    public interface IRepository :
        INotifyCollectionChanged,
        INotifyPropertyChanged,
        IEnumerable,
        ICollection,
        IList
    { }

    public interface IRepository<TEntity> :
        ICollection<TEntity>,
        IEnumerable<TEntity>,
        IList<TEntity>,
        IReadOnlyCollection<TEntity>,
        IReadOnlyList<TEntity>,
        IRepository
        where TEntity : IEntity<Guid>
    {
        void AddRange(IEnumerable<TEntity> entity);
    }
}
