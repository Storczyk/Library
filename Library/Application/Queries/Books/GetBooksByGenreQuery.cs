using Library.Application.General;
using Library.DomainModel.Enums;

namespace Library.Application.Queries.Books
{
    public class GetBooksByGenreQuery : IQuery<PaginatedList<BookQuery>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public Genre Genre { get; set; }
    }
}
