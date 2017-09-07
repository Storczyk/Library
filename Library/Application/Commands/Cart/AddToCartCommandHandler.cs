using Library.Application.General;
using Library.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Library.Application.Commands.Cart
{
    public class AddToCartCommandHandler : ICommandHandler<AddToCartCommand>
    {
        private readonly IBookRepository bookRepository;
        private readonly string Cart = "cart_";
        public AddToCartCommandHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public CommandResult Handle(AddToCartCommand createOrderCommand)
        {
            if (IsMoreThanFive(createOrderCommand.CurrentSession))
            {
                return new CommandResult
                {
                    Result = "You can only have 5 books in cart"
                };
            }

            createOrderCommand.CurrentSession.SetString("cart_" + createOrderCommand.Id.ToString(), createOrderCommand.Id.ToString());

            var book = bookRepository.GetByID(createOrderCommand.Id);
            return new CommandResult
            {
                Result = $"{book.BookTitle} added to the cart"
            };
        }

        private bool IsMoreThanFive(ISession session)
        {
            return session.Keys.Count(i => i.Contains(Cart)) >= 5;
        }
    }
}
