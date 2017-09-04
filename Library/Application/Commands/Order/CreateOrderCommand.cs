using Library.Application.General;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;

namespace Library.Application.Commands.Order
{
    public class CreateOrderCommand : ICommand
    {
        public string Address { get; set; }

        public int PhoneNumber { get; set; }

        public IEnumerable<string> BooksIds { get; set; }

        public ISession Session { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
