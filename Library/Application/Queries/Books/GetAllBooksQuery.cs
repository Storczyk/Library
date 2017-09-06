using Library.Application.General;
using System.Collections.Generic;

namespace Library.Application.Queries.Books
{
    public class GetAllBooksQuery : IQuery<PaginatedList<BookQuery>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
