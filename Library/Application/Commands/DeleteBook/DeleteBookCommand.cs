using Library.Application.General;

namespace Library.Application.Commands.DeleteBook
{
    public class DeleteBookCommand : ICommand
    {
        public string Id { get; set; }
    }
}
