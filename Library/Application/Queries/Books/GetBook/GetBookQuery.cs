using Library.Application.General;

namespace Library.Application.Queries.Books.GetBook
{
    public class GetBookQuery : IQuery<BookQuery>
    {
        public string Id { get; set; }
    }
}
