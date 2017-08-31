using Library.Application.General;
using Microsoft.AspNetCore.Http;
using System;

namespace Library.Application.Commands.Cart
{
    public class RemoveFromCartCommand : ICommand
    {
        public Guid BookGuid { get; set; }

        public ISession CurrentSession { get; set; }
    }
}
