using DryIoc;
using Prism.Commands;
using PVBot.Application.Contracts;
using PVBot.DataObjects.Contracts;

namespace PVBot.Application.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IContainer _container;

        public CommandFactory(IContainer container) => _container = container;

        public DelegateCommand Make<TCommand>() where TCommand : ICommand
        {
            var command = _container.Resolve<TCommand>();

            return new DelegateCommand(command.Execute);
        }
    }
}
