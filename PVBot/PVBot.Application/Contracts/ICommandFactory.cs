using Prism.Commands;
using PVBot.DataObjects.Contracts;

namespace PVBot.Application.Contracts
{
    public interface ICommandFactory
    {
        DelegateCommand Make<TCommand>() where TCommand : ICommand;
    }

    public interface IQueryFactory
    {
        TQuery Make<TQuery>() where TQuery : IQueryBase;
    }
}
