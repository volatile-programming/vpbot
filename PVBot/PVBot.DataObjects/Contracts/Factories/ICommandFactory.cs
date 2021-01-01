using PVBot.DataObjects.Contracts.Core;

namespace PVBot.DataObjects.Contracts.Factories
{
    public interface ICommandFactory
    {
        TCommand MakeCommand<TCommand>() where TCommand : ICommandBase;
    }
}
