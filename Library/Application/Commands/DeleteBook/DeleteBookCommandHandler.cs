using Library.Application.General;
using Library.DomainModel;
using Library.Infrastructure.Data;
using System;

namespace Library.Application.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : ICommandHandler<DeleteBookCommand>
    {
        private readonly BookRepository repository;
        public DeleteBookCommandHandler(BookRepository repository)
        {
            this.repository = repository;
        }
        public void Handle(DeleteBookCommand command)
        {
            repository.Delete(Guid.Parse(command.Id));
        }
    }
}
