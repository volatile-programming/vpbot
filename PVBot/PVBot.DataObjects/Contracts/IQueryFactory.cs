namespace PVBot.DataObjects.Contracts
{
    public interface IQueryFactory
    {
        TQuery Make<TQuery>() where TQuery : IQueryBase;
    }
}
