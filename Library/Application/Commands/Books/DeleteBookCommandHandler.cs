using Library.Application.General;
using Library.Infrastructure.Data;
using System;

namespace Library.Application.Commands.Books
{
    public class DeleteBookCommandHandler : ICommandHandler<DeleteBookCommand>
    {
        private readonly IBookRepository bookRepository;

        public DeleteBookCommandHandler(IBookRepository repository)
        {
            this.bookRepository = repository;
        }

        public CommandResult Handle(DeleteBookCommand command)
        {
            var isDeleted = bookRepository.Delete(Guid.Parse(command.Id));

            string result = isDeleted ? $"Book deleted from the library" : $"Could not delete from the library";

            return new CommandResult
            {
                Result = result
            };
        }
    }
}
