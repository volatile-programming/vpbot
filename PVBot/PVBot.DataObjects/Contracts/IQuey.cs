namespace PVBot.DataObjects.Contracts
{
    public interface IQuery<TQuery, TResult> : IQueryBase, System.Windows.Input.ICommand
    {
        TResult Execute(TQuery query);
    }

    public interface IQueryBase { }
}
