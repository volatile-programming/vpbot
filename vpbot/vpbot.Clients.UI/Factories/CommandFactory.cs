using DryIoc;
using VPBot.DataObjects.Contracts.Core;
using VPBot.DataObjects.Contracts.Factories;

namespace VPBot.Clients.UI.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IContainer _container;

        public CommandFactory(IContainer container) => _container = container;

        public TCommand MakeCommand<TCommand>() where TCommand : ICommandBase
        {
            var command = (TCommand)_container.Resolve(typeof(TCommand),
                IfUnresolved.ReturnDefault);

            return command;
        }
    }
}
