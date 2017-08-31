using Library.Application.General;
using Library.Application.Queries.Books;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Queries.Cart
{
    public class GetBooksFromCartQuery:IQuery<IEnumerable<BookQuery>>
    {
        public ISession CurrentSession { get; set; }
    }
}
