using PVBot.DataObjects.Contracts.Core;

namespace PVBot.DataObjects.Contracts.Factories
{
    public interface IQueryFactory
    {
        TQuery MakeQuery<TQuery>() where TQuery : IQueryBase;
    }
}
