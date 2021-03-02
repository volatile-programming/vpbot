using System;
using System.Threading.Tasks;

namespace VPBot.DataObjects.Contracts.Core
{
    public interface IUnitOfWork
    {
        IPersistence<TEntity> GetPersistence<TEntity>(Type typeEntity)
             where TEntity : class, IEntity<Guid>;
        void CommitChanges(Action<string> errorCallback = null);
        Task CommitChangesAsync(Action<string> errorCallback = null);
    }
}
