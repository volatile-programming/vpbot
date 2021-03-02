using System;
using DryIoc;
using VPBot.DataObjects.Contracts.Core;
using VPBot.DataObjects.Contracts.Factories;

namespace VPBot.Clients.UI.Factories
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
