using DryIoc;
using PVBot.DataObjects.Contracts.Core;
using PVBot.DataObjects.Contracts.Factories;

namespace PVBot.Application.Factories
{
    public class QueryFactory : IQueryFactory
    {
        private readonly IContainer _container;

        public QueryFactory(IContainer container) => _container = container;


        public TQuery MakeQuery<TQuery>() where TQuery : IQueryBase
        {
            var query = (TQuery)_container.Resolve(typeof(TQuery),
                IfUnresolved.ReturnDefault);

            return query;
        }
    }
}
