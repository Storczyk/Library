using Library.Application.General;
using Library.Infrastructure.Data;

namespace Library.Application.Commands.Cart
{
    public class RemoveFromCartCommandHandler : ICommandHandler<RemoveFromCartCommand>
    {
        private readonly IBookRepository bookRepository;

        public RemoveFromCartCommandHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public CommandResult Handle(RemoveFromCartCommand command)
        {
            command.CurrentSession.Remove("cart_" + command.Id.ToString());
            var book = bookRepository.GetByID(command.Id);

            return new CommandResult
            {
                Result = $"{book.BookTitle} removed from the cart"
            };
        }
    }
}
