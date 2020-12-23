using DryIoc;
using PVBot.Application.Contracts;
using PVBot.DataObjects.Contracts;

namespace PVBot.Application.Factories
{
    public class QueryFactory : IQueryFactory
    {
        private readonly IContainer _container;

        public QueryFactory(IContainer container) => _container = container;


        public TQuery Make<TQuery>() where TQuery : IQueryBase
        {
            var query = _container.Resolve<TQuery>();

            return query;
        }
    }
}
