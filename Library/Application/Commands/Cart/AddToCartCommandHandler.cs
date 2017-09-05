using Library.Application.General;
using Library.Infrastructure.Data;
using Microsoft.AspNetCore.Http;

namespace Library.Application.Commands.Cart
{
    public class AddToCartCommandHandler : ICommandHandler<AddToCartCommand>
    {
        private readonly IBookRepository bookRepository;

        public AddToCartCommandHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public CommandResult Handle(AddToCartCommand command)
        {
            command.CurrentSession.SetString("cart_" + command.Id.ToString(), command.Id.ToString());
            var book = bookRepository.GetByID(command.Id);

            return new CommandResult
            {
                Result = $"{book.BookTitle} added to the cart"
            };
        }
    }
}
