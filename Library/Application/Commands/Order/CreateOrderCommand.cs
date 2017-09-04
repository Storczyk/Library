using Library.Application.General;
using Library.Application.Queries.Books;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Library.Application.Commands.Order
{
    public class CreateOrderCommand : ICommand
    {
        public string Address { get; set; }

        public int PhoneNumber { get; set; }

        public IEnumerable<string> BooksIds { get; set; }

        public ISession Session { get; set; }
    }
}
