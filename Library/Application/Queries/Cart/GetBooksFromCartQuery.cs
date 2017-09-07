using Library.Application.General;
using Library.Application.Queries.Books;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Library.Application.Queries.Cart
{
    public class GetBooksFromCartQuery:IQuery<IEnumerable<BookQuery>>
    {
        public ISession CurrentSession { get; set; }
    }
}
