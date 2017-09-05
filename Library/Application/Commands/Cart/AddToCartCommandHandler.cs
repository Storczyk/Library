using Library.Application.General;
using Microsoft.AspNetCore.Http;

namespace Library.Application.Commands.Cart
{
    public class AddToCartCommandHandler : ICommandHandler<AddToCartCommand>
    {
        public CommandResult Handle(AddToCartCommand command)
        {
            command.CurrentSession.SetString("cart_" + command.Id.ToString(), command.Id.ToString());

            return new CommandResult
            {
                Result = "Book added to the cart"
            };
        }
    }
}
