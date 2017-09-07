using Library.Application.General;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Library.Application.Queries.Cart
{
    public class GetBooksIdsFromCartQuery : IQuery<IEnumerable<string>>
    {
        public ISession CurrentSession { get; set; }
    }
}
