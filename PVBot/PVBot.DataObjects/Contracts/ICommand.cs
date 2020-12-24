namespace PVBot.DataObjects.Contracts
{
    public interface ICommand
    {
        void Execute();
    }

    public interface ICommand<TParam>
    {
        void Execute(TParam param);

    }
}
