using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading.Tasks;

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
        void Refresh();
        Task RefreshAsync();
        Task ClearAsync();
        Task AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entity);
        Task AddRangeAsync(IEnumerable<TEntity> entity);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
