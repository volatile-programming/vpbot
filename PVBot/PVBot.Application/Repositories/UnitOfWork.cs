using System;
using System.Threading.Tasks;
using PVBot.DataObjects.Contracts.Core;

namespace PVBot.Application.Repositories
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity>
        where TEntity : class, IEntity<Guid>
    {
        public UnitOfWork(IPersistence<TEntity> persistence)
        {
            Persistence = persistence;
        }

        public IPersistence<TEntity> Persistence { get; }

        public void CommitChanges()
        {
        }

        public Task CommitChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}
