namespace PVBot.DataObjects.Contracts
{
    public interface ICommandFactory
    {
        TWrapper MakeCommand<TCommand, TWrapper>() where TCommand : ICommand;
    }
}
