using Library.Application.General;
using Library.DomainModel;
using Library.Infrastructure.Data;

namespace Library.Application.Commands.Books
{
    public class AddBookCommandHandler : ICommandHandler<AddBookCommand>
    {
        private readonly IBookRepository repository;

        public AddBookCommandHandler(IBookRepository repository)
        {
            this.repository = repository;
        }

        public CommandResult Handle(AddBookCommand command)
        {
            var isAdded = repository.Insert(new Book
            {
                Author = new Author
                {
                    Name = command.Author
                },
                Genre = command.Genre,
                BookTitle = command.BookTitle,
                Description = command.Description,
                Ean = command.Ean,
                Isbn = command.Isbn,
                Pages = command.Pages,
                Publisher = command.Publisher,
                Year = command.Year,
                Quantity = command.Quantity,
            });

            string result = isAdded ? $"{command.BookTitle} added to the library" : $"Could not add {command.BookTitle} to the library";

            return new CommandResult
            {
                Result = result
            };
        }
    }
}
