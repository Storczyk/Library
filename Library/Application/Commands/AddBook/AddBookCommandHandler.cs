using Library.Application.General;

namespace Library.Application.Commands.AddBook
{
    public class AddBookCommandHandler : ICommandHandler<AddBookCommand>
    {
        public void Handle(AddBookCommand command)
        {
            //repo.AddBook(command);
        }
    }
}
