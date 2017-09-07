using Library.Application.General;
using Library.DomainModel;
using Library.Infrastructure.Data;
using System.IO;

namespace Library.Application.Commands.Books
{
    public class AddBookCommandHandler : ICommandHandler<AddBookCommand>
    {
        private int DescriptionMaxLength = 493;
        private readonly IBookRepository repository;

        public AddBookCommandHandler(IBookRepository repository)
        {
            this.repository = repository;
        }

        public CommandResult Handle(AddBookCommand command)
        {
            var book = new Book
            {
                Author = new Author
                {
                    Name = command.Author
                },
                Genre = command.Genre,
                BookTitle = command.BookTitle,
                Description = command.Description.Length > DescriptionMaxLength ? command.Description.Substring(0, DescriptionMaxLength) : command.Description,
                Ean = command.Ean,
                Isbn = command.Isbn,
                Pages = command.Pages,
                Publisher = command.Publisher,
                Year = command.Year,
                Quantity = command.Quantity,
            };
            if (command.Image !=null || command.Image.ContentType.ToLower().StartsWith("image/"))
            {
                MemoryStream ms = new MemoryStream();
                command.Image.OpenReadStream().CopyTo(ms);
                
                book.Image = ms.ToArray();
            }
            var isAdded = repository.Insert(book);

            string result = isAdded ? $"{command.BookTitle} added to the library" : $"Could not add {command.BookTitle} to the library";

            return new CommandResult
            {
                Result = result
            };
        }
    }
}
