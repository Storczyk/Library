using Library.Application.General;
using Library.Application.Queries.Books;
using System.Collections.Generic;

namespace Library.Application.Queries.Books
{
    public class SearchBooksByTitleQuery : IQuery<IEnumerable<BookQuery>>
    {
        public string Title { get; set; }
    }
}
