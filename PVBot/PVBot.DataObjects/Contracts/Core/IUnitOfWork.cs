using System;
using System.Threading.Tasks;

namespace PVBot.DataObjects.Contracts.Core
{
    public interface IUnitOfWork<TEntity> where TEntity : class, IEntity<Guid>
    {
        IPersistence<TEntity> Persistence { get; }
        void CommitChanges();
        Task CommitChangesAsync();
    }
}
