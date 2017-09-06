using Library.Application.General;
using Library.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Queries.Books
{
    public class GetBooksByGenreQueryHandler : IQueryHandler<GetBooksByGenreQuery, PaginatedList<BookQuery>>
    {
        private readonly IBookRepository bookRepository;
        private readonly IOrderRepository orderRepository;

        public GetBooksByGenreQueryHandler(IBookRepository bookRepository, IOrderRepository orderRepository)
        {
            this.bookRepository = bookRepository;
            this.orderRepository = orderRepository;
        }

        public PaginatedList<BookQuery> Handle(GetBooksByGenreQuery query)
        {
            var list = bookRepository.GetByGenre(query.Genre, query.Page < 1 ? 1 : query.Page, query.PageSize < 1 ? 10 : query.PageSize);
            foreach (var book in list)
            {
                var currentQuantity = orderRepository.GetCurrentQuantityForBook(Guid.Parse(book.Id));
                book.CurrentQuantity = book.Quantity - currentQuantity >= 0 ? book.Quantity - currentQuantity : 0;
            }

            return list;
        }
    }
}
