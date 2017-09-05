using Library.Application.General;
using Microsoft.AspNetCore.Http;

namespace Library.Application.Commands.Cart
{
    public class AddToCartCommandHandler : ICommandHandler<AddToCartCommand>
    {
        public CommandResult Handle(AddToCartCommand createOrderCommand)
        {
            createOrderCommand.CurrentSession.SetString("cart_" + createOrderCommand.Id.ToString(), createOrderCommand.Id.ToString());

            return new CommandResult
            {
                Result = "Book added to the cart"
            };
        }
    }
}
