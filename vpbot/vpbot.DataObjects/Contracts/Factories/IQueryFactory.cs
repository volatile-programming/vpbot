using VPBot.DataObjects.Contracts.Core;

namespace VPBot.DataObjects.Contracts.Factories
{
    public interface IQueryFactory
    {
        TQuery MakeQuery<TQuery>() where TQuery : IQueryBase;
    }
}
