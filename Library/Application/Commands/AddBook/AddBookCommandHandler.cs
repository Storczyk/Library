using Library.Application.General;
using Library.DomainModel;
using Library.Infrastructure.Data;

namespace Library.Application.Commands.AddBook
{
    public class AddBookCommandHandler : ICommandHandler<AddBookCommand>
    {
        private readonly Repository<Book> repository;
        public AddBookCommandHandler(Repository<Book> repository)
        {
            this.repository = repository;
        }
        public void Handle(AddBookCommand command)
        {
            repository.Insert(new Book
            {
                Author = command.Author,
                BookTitle = command.BookTitle,
                Description = command.Description,
                Ean = command.Ean,
                Isbn = command.Isbn,
                Pages = command.Pages,
                Publisher = command.Publisher,
                Year = command.Year
            });
        }
    }
}
