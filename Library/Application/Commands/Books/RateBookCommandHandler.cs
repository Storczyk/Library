using Library.Application.General;

namespace Library.Application.Commands.Books
{
    public class RateBookCommandHandler : ICommandHandler<RateBookCommand>
    {
        public CommandResult Handle(RateBookCommand command)
        {
            return new CommandResult { Result = "OK" };
        }
    }
}
