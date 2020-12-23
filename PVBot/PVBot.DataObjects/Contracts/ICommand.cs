namespace PVBot.DataObjects.Contracts
{
    public interface ICommand : System.Windows.Input.ICommand
    {
        void Execute();
    }
}
