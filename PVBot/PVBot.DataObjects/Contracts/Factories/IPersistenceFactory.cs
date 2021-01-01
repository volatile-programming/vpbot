using System;
using PVBot.DataObjects.Contracts.Core;

namespace PVBot.DataObjects.Contracts.Factories
{
    public interface IPersistenceFactory
    {
        IPersistence<TEntity> MakePersistence<TEntity>() where TEntity : class, IEntity<Guid>;
    }
}
