using Library.Application.General;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Commands.Cart
{
    public class AddToCartCommandHandler : ICommandHandler<AddToCartCommand>
    {
        public void Handle(AddToCartCommand command)
        {
            command.CurrentSession.SetString("cart_" + command.Id.ToString(), command.Id.ToString());
        }
    }
}
