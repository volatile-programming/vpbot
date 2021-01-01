using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PVBot.DataObjects.Contracts.Core;

namespace PVBot.Application.Repositories
{
    public class Persistence<TEntity> : IPersistence<TEntity>
        where TEntity : class, IEntity<Guid>
    {
        public void Add(TEntity entity)
        {
        }

        public Task AddAsync(TEntity entity)
        {
            return Task.CompletedTask;
        }

        public TEntity Find(TEntity entity)
        {
            return null;
        }

        public TEntity Find(Func<TEntity, bool> query)
        {
            return null;
        }

        public List<TEntity> GetAll()
        {
            return null;
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return null;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
        }

        public Task RemoveAsync(TEntity entity)
        {
            return Task.CompletedTask;
        }

        public void Update(TEntity message)
        {
        }

        public Task UpdateAsync(TEntity message)
        {
            return Task.CompletedTask;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
