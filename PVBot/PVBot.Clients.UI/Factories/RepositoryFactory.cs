using DryIoc;
using PVBot.DataObjects.Contracts.Core;
using PVBot.DataObjects.Contracts.Factories;

namespace PVBot.Clients.UI.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IContainer _container;

        public RepositoryFactory(IContainer container) => _container = container;

        public TRepository MakeRepository<TRepository>() where TRepository : IRepository
        {
            var query = (TRepository)_container.Resolve(typeof(TRepository),
                IfUnresolved.ReturnDefault);

            return query;
        }
    }
}
