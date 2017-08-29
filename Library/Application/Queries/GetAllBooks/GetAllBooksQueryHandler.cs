using Library.Application.General;
using System.Collections.Generic;

namespace Library.Application.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IQueryHandler<GetAllBooksQuery, IEnumerable<BookQuery>>
    {
        public IEnumerable<BookQuery> Handle(GetAllBooksQuery query)
        {
            return null;
        }
    }
}
