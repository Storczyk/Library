using Library.Application.General;

namespace Library.Application.Commands.Books
{
    public class DeleteBookCommand : ICommand
    {
        public string Id { get; set; }
    }
}
