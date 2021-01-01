using System;
using PVBot.DataObjects.Contracts.Core;

namespace PVBot.DataObjects.Base
{
    public abstract class BaseCommand<TCommand> : ICommandBase
        where TCommand : ICommandBase
    {
        private readonly Func<bool> _canExecute;
        public event EventHandler CanExecuteChanged;

        public BaseCommand(Func<bool> canExecute = null) =>
            _canExecute = canExecute;

        public bool CanExecute(object parameter) => RaiceCanExecute();

        public bool RaiceCanExecute()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

            var canExecute = _canExecute?.Invoke() ?? true;

            return canExecute;
        }

        public abstract void Execute(object parameter);
    }
}
