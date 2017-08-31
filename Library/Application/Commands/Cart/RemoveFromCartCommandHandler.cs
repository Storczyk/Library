using Library.Application.General;

namespace Library.Application.Commands.Cart
{
    public class RemoveFromCartCommandHandler : ICommandHandler<RemoveFromCartCommand>
    {
        public void Handle(RemoveFromCartCommand command)
        {
            command.CurrentSession.Remove("cart_" + command.BookGuid.ToString());
        }
    }
}
