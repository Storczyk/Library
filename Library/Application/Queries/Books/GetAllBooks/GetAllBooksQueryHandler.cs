using Library.Application.General;
using Library.DomainModel;
using Library.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Library.Application.Queries.Books.GetAllBooks
{
    public class GetAllBooksQueryHandler : IQueryHandler<GetAllBooksQuery, IEnumerable<BookQuery>>
    {
        private readonly IBookRepository repository;
        public GetAllBooksQueryHandler(IBookRepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<BookQuery> Handle(GetAllBooksQuery query)
        {
            var list = repository.Get(query.Page, query.PageSize).Select(i => new BookQuery
            {
                Author = i.Author,
                Genre = i.Genre,
                Description = i.Description,
                BookTitle = i.BookTitle,
                Ean = i.Ean,
                Id = i.BookId.ToString(),
                Isbn = i.Isbn,
                Pages = i.Pages,
                Publisher = i.Publisher,
                Year = i.Year,
            }).ToList();
            return list;
        }
    }
}
