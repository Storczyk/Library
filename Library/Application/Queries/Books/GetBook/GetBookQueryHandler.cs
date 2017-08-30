using Library.Application.General;
using Library.DomainModel;
using Library.Infrastructure.Data;
using System;
using System.Linq;
namespace Library.Application.Queries.Books.GetBook
{
    public class GetBookQueryHandler : IQueryHandler<GetBookQuery, BookQuery>
    {
        private readonly IBookRepository repository;
        public GetBookQueryHandler(IBookRepository repository)
        {
            this.repository = repository;
        }
        public BookQuery Handle(GetBookQuery query)
        {
            var x = repository.GetByID(Guid.Parse(query.Id));
            return new BookQuery
            {
                Id = x.Id.ToString(),
                Author = x.Author,
                BookTitle = x.BookTitle,
                Description = x.Description,
                Ean = x.Ean,
                Genre = x.Genre,
                Isbn = x.Isbn,
                Pages = x.Pages,
                Publisher = x.Publisher,
                Year = x.Year,
            };
        }
    }
}
