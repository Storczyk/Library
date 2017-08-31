using Library.Application.General;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Commands.Cart
{
    public class AddToCartCommand : ICommand
    {
        public Guid Id { get; set; }

        public ISession CurrentSession { get; set; }
    }
}
