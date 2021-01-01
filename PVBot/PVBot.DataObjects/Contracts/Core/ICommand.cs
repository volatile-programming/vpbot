namespace PVBot.DataObjects.Contracts.Core
{
    public interface ICommandBase { }

    public interface ICommand : ICommandBase
    {
        void Execute();
    }

    public interface ICommand<TParam> : ICommandBase
    {
        void Execute(TParam param);
    }
}
