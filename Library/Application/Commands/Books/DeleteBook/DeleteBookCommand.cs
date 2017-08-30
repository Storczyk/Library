using Library.Application.General;

namespace Library.Application.Commands.Books.DeleteBook
{
    public class DeleteBookCommand : ICommand
    {
        public string Id { get; set; }
    }
}
