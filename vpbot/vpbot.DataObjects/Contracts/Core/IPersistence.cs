using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VPBot.DataObjects.Contracts.Core
{
    public interface IPersistence<TEntity> where TEntity : class, IEntity<Guid>
    {
        IUnitOfWork UnitOfWork { get; set; }
        void Add(TEntity entity);
        bool Any(Func<TEntity, bool> query);
        TEntity Find(Expression<Func<TEntity, bool>> query);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> query);
        List<TEntity> Query(Expression<Func<TEntity, bool>> query = null);
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> query = null);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
