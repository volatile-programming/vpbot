using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PVBot.DataObjects.Contracts.Core
{
    public interface IPersistence<TEntity> : IEnumerable<TEntity>
        where TEntity : class, IEntity<Guid>
    {
        TEntity Find(TEntity entity);
        TEntity Find(Func<TEntity, bool> query);
        List<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void Update(TEntity message);
        Task UpdateAsync(TEntity message);
        void Remove(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
