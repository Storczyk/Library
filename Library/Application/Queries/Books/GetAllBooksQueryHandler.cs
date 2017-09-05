using Library.Application.General;
using Library.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Application.Queries.Books
{
    public class GetAllBooksQueryHandler : IQueryHandler<GetAllBooksQuery, IEnumerable<BookQuery>>
    {
        private readonly IBookRepository bookRepository;
        private readonly IOrderRepository orderRepository;

        public GetAllBooksQueryHandler(IBookRepository bookRepository, IOrderRepository orderRepository)
        {
            this.bookRepository = bookRepository;
            this.orderRepository = orderRepository;
        }

        public IEnumerable<BookQuery> Handle(GetAllBooksQuery query)
        {
            var list = bookRepository.Get(query.Page, query.PageSize).Select(i => new BookQuery
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
                Quantity = i.Quantity,
            }).ToList();

            foreach(var book in list)
            {
                var currentQuantity = orderRepository.GetCurrentQuantityForBook(Guid.Parse(book.Id));
                book.CurrentQuantity = book.Quantity > 0 ? book.Quantity - currentQuantity : 0; 
            }

            return list;
        }
    }
}
