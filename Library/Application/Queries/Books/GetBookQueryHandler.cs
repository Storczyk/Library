using Library.Application.General;
using Library.Infrastructure.Data;
using System;
namespace Library.Application.Queries.Books
{
    public class GetBookQueryHandler : IQueryHandler<GetBookQuery, BookQuery>
    {
        private readonly IBookRepository bookRepository;
        private readonly IOrderRepository orderRepository;

        public GetBookQueryHandler(IBookRepository bookRepository, IOrderRepository orderRepository)
        {
            this.bookRepository = bookRepository;
            this.orderRepository = orderRepository;
        }

        public BookQuery Handle(GetBookQuery bookQuery)
        {
            var currentQuantity = orderRepository.GetCurrentQuantityForBook(Guid.Parse(bookQuery.Id));
            var book = bookRepository.GetByID(Guid.Parse(bookQuery.Id));

            return new BookQuery
            {
                Id = book.BookId.ToString(),
                Author = book.Author,
                BookTitle = book.BookTitle,
                Description = book.Description,
                Ean = book.Ean,
                Genre = book.Genre,
                Isbn = book.Isbn,
                Pages = book.Pages,
                Publisher = book.Publisher,
                Year = book.Year,
                Quantity = book.Quantity,
                CurrentQuantity = book.Quantity - currentQuantity >= 0 ? book.Quantity - currentQuantity : 0,
                Image = book.Image,
            };
        }
    }
}
