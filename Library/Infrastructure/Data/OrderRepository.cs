using Library.Application.Queries.Books;
using Library.Application.Queries.Order;
using Library.DomainModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LibraryDbContext context;

        public OrderRepository()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server=PSROCZYK-RZE\\SQLEXPRESS;Database=libraryDB;User Id=test;Password=test;MultipleActiveResultSets=True");
            context = new LibraryDbContext(options.Options);
        }

        public IEnumerable<OrderQuery> GetAll(int page = 1, int pageSize = 50)
        {
            if (page < 1)
            {
                page = 1;
            }
            if (pageSize < 1)
            {
                pageSize = 10;
            }

            return context.Orders.Skip(pageSize * (page - 1)).Take(pageSize).Include(o => o.OrderDetails).Select(i => new OrderQuery
            {
                Address = i.Address,
                PhoneNumber = i.PhoneNumber,
                Books = i.OrderDetails.Select(j => new BookQuery
                {
                    Author = j.Book.Author,
                    BookTitle = j.Book.BookTitle,
                    Description = j.Book.Description,
                    Ean = j.Book.Ean,
                    Genre = j.Book.Genre,
                    Id = j.Book.BookId.ToString(),
                    Isbn = j.Book.Isbn,
                    Pages = j.Book.Pages,
                    Publisher = j.Book.Publisher,
                    Year = j.Book.Year,
                })
            }).ToList();
        }
    }
}
