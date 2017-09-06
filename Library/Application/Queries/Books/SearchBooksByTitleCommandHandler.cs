using Library.Application.General;
using Library.Infrastructure.Data;
using System;
using System.Collections.Generic;

namespace Library.Application.Queries.Books
{
    public class SearchBooksByTitleQueryHandler : IQueryHandler<SearchBooksByTitleQuery, IEnumerable<BookQuery>>
    {
        private readonly IBookRepository bookRepository;
        private readonly IOrderRepository orderRepository;

        public SearchBooksByTitleQueryHandler(IBookRepository bookRepository, IOrderRepository orderRepository)
        {
            this.bookRepository = bookRepository;
            this.orderRepository = orderRepository;
        }

        public IEnumerable<BookQuery> Handle(SearchBooksByTitleQuery query)
        {
            var books = bookRepository.GetByTitle(query.Title);
            foreach (var book in books)
            {
                var currentQuantity = orderRepository.GetCurrentQuantityForBook(Guid.Parse(book.Id));
                book.CurrentQuantity = book.Quantity - currentQuantity >= 0 ? book.Quantity - currentQuantity : 0;
            }

            return books;
        }
    }
}
