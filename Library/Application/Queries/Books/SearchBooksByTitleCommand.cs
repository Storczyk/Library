using Library.Application.General;
using Library.Application.Queries.Books;
using System.Collections.Generic;

namespace Library.Application.Queries.Books
{
    public class SearchBooksByTitleQuery : IQuery<PaginatedList<BookQuery>>
    {
        public string Title { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
