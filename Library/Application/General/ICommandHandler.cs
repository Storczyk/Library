namespace Library.Application.General
{
    public interface ICommandHandler
    {

    }
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
