using Library.Application.General;
using Library.Infrastructure.Data;
using System;

namespace Library.Application.Queries.Books
{
    public class GetAllBooksQueryHandler : IQueryHandler<GetAllBooksQuery, PaginatedList<BookQuery>>
    {
        private readonly IBookRepository bookRepository;
        private readonly IOrderRepository orderRepository;

        public GetAllBooksQueryHandler(IBookRepository bookRepository, IOrderRepository orderRepository)
        {
            this.bookRepository = bookRepository;
            this.orderRepository = orderRepository;
        }

        public PaginatedList<BookQuery> Handle(GetAllBooksQuery query)
        {
            var list = bookRepository.Get(query.Page < 1 ? 1 : query.Page, query.PageSize < 1 ? 10 : query.PageSize);

            foreach(var book in list)
            {
                var currentQuantity = orderRepository.GetCurrentQuantityForBook(Guid.Parse(book.Id));
                book.CurrentQuantity = book.Quantity - currentQuantity >= 0 ? book.Quantity - currentQuantity : 0; 
            }

            return list;
        }
    }
}
