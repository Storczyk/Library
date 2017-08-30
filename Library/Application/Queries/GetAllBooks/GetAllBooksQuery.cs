using Library.Application.General;
using System.Collections.Generic;

namespace Library.Application.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IQuery<IEnumerable<BookQuery>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
