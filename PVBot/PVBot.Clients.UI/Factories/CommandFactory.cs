using System;
using DryIoc;
using Prism.Commands;
using PVBot.DataObjects.Contracts;

namespace PVBot.Application.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IContainer _container;

        public CommandFactory(IContainer container) => _container = container;

        public TWrapper MakeCommand<TCommand, TWrapper>()
            where TCommand : ICommand
        {
            var command = (TCommand)_container.Resolve(typeof(TCommand), IfUnresolved.Throw);
            Action method = command.Execute;

            var delegateCommand = (TWrapper)Activator
                .CreateInstance(typeof(TWrapper), method);

            return delegateCommand;
        }

        public DelegateCommand<TParam> MakeCommandWithParmeter<TCommand, TParam>()
            where TCommand : ICommand<TParam>
        {
            var command = (TCommand)_container.Resolve(typeof(TCommand), IfUnresolved.Throw);
            Action<TParam> method = command.Execute;

            var delegateCommand = new DelegateCommand<TParam>(method);

            return delegateCommand;
        }
    }
}
