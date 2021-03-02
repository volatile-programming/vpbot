using DryIoc;
using VPBot.DataObjects.Contracts.Core;
using VPBot.DataObjects.Contracts.Factories;

namespace VPBot.Application.Factories
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
