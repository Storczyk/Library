using Library.Application.General;
using Library.DomainModel;
using Library.Infrastructure.Data;
using System;

namespace Library.Application.Commands.Books
{
    public class EditBookCommandHandler : ICommandHandler<EditBookCommand>
    {
        private readonly IBookRepository bookRepository;

        public EditBookCommandHandler(IBookRepository repository)
        {
            this.bookRepository = repository;
        }

        public CommandResult Handle(EditBookCommand command)
        {
            var isUpdated = bookRepository.Update(new Book
            {
                BookId = Guid.Parse(command.Id),
                Author = new Author { Name = command.Author },
                Genre = command.Genre,
                BookTitle = command.BookTitle,
                Description = command.Description,
                Ean = command.Ean,
                Isbn = command.Isbn,
                Pages = command.Pages,
                Publisher = command.Publisher,
                Year = command.Year,
                Quantity = command.Quantity
            });

            string result = isUpdated ? $"{command.BookTitle} edited" : $"Could not edit {command.BookTitle}";

            return new CommandResult
            {
                Result = result
            };
        }
    }
}
