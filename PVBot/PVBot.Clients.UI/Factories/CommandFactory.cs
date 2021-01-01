using DryIoc;
using PVBot.DataObjects.Contracts.Core;
using PVBot.DataObjects.Contracts.Factories;

namespace PVBot.Clients.UI.Factories
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
