using System;
using VPBot.DataObjects.Contracts.Core;

namespace VPBot.DataObjects.Contracts.Factories
{
    public interface IPersistenceFactory
    {
        IPersistence<TEntity> MakePersistence<TEntity>() where TEntity : class, IEntity<Guid>;
    }
}
