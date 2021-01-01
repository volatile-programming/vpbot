using PVBot.DataObjects.Contracts.Core;

namespace PVBot.DataObjects.Contracts.Factories
{
    public interface IRepositoryFactory
    {
        TRepository MakeRepository<TRepository>() where TRepository : IRepository;
    }
}
