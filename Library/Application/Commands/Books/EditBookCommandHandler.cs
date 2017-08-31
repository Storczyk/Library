using Library.Application.General;
using Library.DomainModel;
using Library.Infrastructure.Data;
using System;

namespace Library.Application.Commands.Books
{
    public class EditBookCommandHandler : ICommandHandler<EditBookCommand>
    {
        private readonly IBookRepository repository;
        public EditBookCommandHandler(IBookRepository repository)
        {
            this.repository = repository;
        }
        public void Handle(EditBookCommand command)
        {
            repository.Update(new Book
            {
                BookId = Guid.Parse(command.Id),
                Author = new Author { Name = command.Author },
                Genre = new Genre { Description = command.Genre },
                BookTitle = command.BookTitle,
                Description = command.Description,
                Ean = command.Ean,
                Isbn = command.Isbn,
                Pages = command.Pages,
                Publisher = command.Publisher,
                Year = command.Year,
            });
        }
    }
}
