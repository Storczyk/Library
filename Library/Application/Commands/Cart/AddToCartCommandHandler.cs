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

        public CommandResult Handle(AddToCartCommand createOrderCommand)
        {
            createOrderCommand.CurrentSession.SetString("cart_" + createOrderCommand.Id.ToString(), createOrderCommand.Id.ToString());
            var book = bookRepository.GetByID(createOrderCommand.Id);
            return new CommandResult
            {
                Result = $"{book.BookTitle} added to the cart"
            };
        }
    }
}
