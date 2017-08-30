using Library.Application.General;
using Library.DomainModel;
using Library.Infrastructure.Data;

namespace Library.Application.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : ICommandHandler<DeleteBookCommand>
    {
        private readonly Repository<Book> repository;
        public DeleteBookCommandHandler(Repository<Book> repository)
        {
            this.repository = repository;
        }
        public void Handle(DeleteBookCommand command)
        {
            repository.Delete(command.Id);
        }
    }
}
