using Library.Application.General;

namespace Library.Application.Commands.Cart
{
    public class RemoveFromCartCommandHandler : ICommandHandler<RemoveFromCartCommand>
    {
        public CommandResult Handle(RemoveFromCartCommand command)
        {
            command.CurrentSession.Remove("cart_" + command.Id.ToString());

            return new CommandResult
            {
                Result = "Book removed from the cart"
            };
        }
    }
}
