namespace Library.Application.General
{
    public interface ICommandHandler
    {

    }
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        CommandResult Handle(TCommand command);
    }
}
