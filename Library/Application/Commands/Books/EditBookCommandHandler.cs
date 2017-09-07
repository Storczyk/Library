using Library.Application.General;
using Library.DomainModel;
using Library.Infrastructure.Data;
using System;
using System.IO;

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
            var book = new Book
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
                Quantity = command.Quantity,
            };

            if (command.Image != null || command.Image.ContentType.ToLower().StartsWith("image/"))
            {
                MemoryStream ms = new MemoryStream();
                command.Image.OpenReadStream().CopyTo(ms);
                book.Image = ms.ToArray();
            }

            var isUpdated = bookRepository.Update(book);
            string result = isUpdated ? $"{command.BookTitle} edited" : $"Could not edit {command.BookTitle}";

            return new CommandResult
            {
                Result = result
            };
        }
    }
}
