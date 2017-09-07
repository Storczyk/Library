using Library.Application.General;

namespace Library.Application.Queries.Books
{
    public class SearchBooksByTitleQuery : IQuery<PaginatedList<BookQuery>>
    {
        public string Title { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
