using System;
using DryIoc;
using PVBot.DataObjects.Contracts.Core;
using PVBot.DataObjects.Contracts.Factories;

namespace PVBot.Clients.UI.Factories
{
    public class PersistenceFactory : IPersistenceFactory
    {
        private readonly IContainer _container;

        public PersistenceFactory(IContainer container) => _container = container;

        public IPersistence<TEntity> MakePersistence<TEntity>()
            where TEntity : class, IEntity<Guid>
        {
            var query = _container.Resolve(typeof(IPersistence<TEntity>),
                IfUnresolved.ReturnDefault) as IPersistence<TEntity>;

            return query;
        }
    }
}
