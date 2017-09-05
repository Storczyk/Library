namespace Library.Application.General
{
    public interface ICommandBus
    {
        CommandResult Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
