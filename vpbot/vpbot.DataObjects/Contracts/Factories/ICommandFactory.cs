using VPBot.DataObjects.Contracts.Core;

namespace VPBot.DataObjects.Contracts.Factories
{
    public interface ICommandFactory
    {
        TCommand MakeCommand<TCommand>() where TCommand : ICommandBase;
    }
}
