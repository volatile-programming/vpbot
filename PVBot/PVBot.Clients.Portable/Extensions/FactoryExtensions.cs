using Prism.Commands;
using PVBot.DataObjects.Contracts.Core;
using PVBot.DataObjects.Contracts.Factories;

namespace PVBot.Clients.Portable.Extensions
{
    public static class FactoryExtensions
    {
        public static DelegateCommand MakeDelegateCommand<TCommand>(
            this ICommandFactory commandFactory)
            where TCommand : ICommand
        {
            var dependency = commandFactory.MakeCommand<TCommand>();

            var command = new DelegateCommand(dependency.Execute);

            return command;
        }

        public static DelegateCommand<TParam> MakeDelegateWithParameter<TCommand, TParam>(
            this ICommandFactory commandFactory)
            where TCommand : ICommand<TParam>
        {
            var dependency = commandFactory.MakeCommand<TCommand>();

            var command = new DelegateCommand<TParam>(dependency.Execute);

            return command;
        }
    }
}
