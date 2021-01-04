using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Prism.Ioc;

using PVBot.DataObjects.Contracts.Core;

namespace PVBot.Application.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Stack<Task> _operations;
        private readonly IContainerProvider container;

        public UnitOfWork(IContainerProvider container)
        {
            _operations = new Stack<Task>();
            this.container = container;
        }

        public async void CommitChanges(Action<string> errorCallback = null)
        {
            try
            {
                while (_operations.Any())
                {
                    var operation = _operations.Pop();

                    await operation;
                }
            }
            catch (Exception ex) when (errorCallback != null)
            {
                errorCallback(ex.Message);
            }
        }

        public async Task CommitChangesAsync(Action<string> errorCallback = null)
        {
            try
            {
                await Task.WhenAll(_operations);
                var allTaskCompleted = !_operations.Any();
            }
            catch (Exception ex) when (errorCallback != null)
            {
                errorCallback(ex.Message);
            }
        }

        public IPersistence<TEntity> GetPersistence<TEntity>(Type typePersistance)
             where TEntity : class, IEntity<Guid>
        {
            var persistance = container.Resolve<IPersistence<TEntity>>();

            if (persistance != null)
                persistance.UnitOfWork = this;

            return persistance;
        }
    }
}
