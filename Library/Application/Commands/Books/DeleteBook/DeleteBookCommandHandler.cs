using Library.Application.General;
using Library.DomainModel;
using Library.Infrastructure.Data;
using System;

namespace Library.Application.Commands.Books.DeleteBook
{
    public class DeleteBookCommandHandler : ICommandHandler<DeleteBookCommand>
    {
        private readonly IBookRepository repository;
        public DeleteBookCommandHandler(IBookRepository repository)
        {
            this.repository = repository;
        }
        public void Handle(DeleteBookCommand command)
        {
            repository.Delete(Guid.Parse(command.Id));
        }
    }
}
