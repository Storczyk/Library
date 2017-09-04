using Library.Application.Queries.Books;
using Library.Application.Queries.Order;
using Library.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
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

        public IEnumerable<OrderQuery> GetAll(int page, int pageSize)
        {
            return context.Orders.Skip(pageSize * (page - 1)).Take(pageSize).Include(i => i.User).Include(i => i.OrderDetails).Select(i => new OrderQuery
            {
                Address = i.Address,
                PhoneNumber = i.PhoneNumber,
                OrderDate = i.OrderDate,
                Books = i.OrderDetails.Select(j => new BookShortQuery
                {
                    BookTitle = j.Book.BookTitle,
                    Author = j.Book.Author,
                    Description = j.Book.Description,
                    Genre = j.Book.Genre,
                })
            }).ToList();
        }

        public void Insert(Order order, IEnumerable<string> booksIds)
        {
            var details = new List<OrderDetails>();
            foreach (var book in booksIds)
            {
                var repoBook = context.Books.Find(Guid.Parse(book));
                details.Add(new OrderDetails
                {
                    Book = repoBook,
                    BookId = repoBook.BookId,
                    ReturnDate = DateTime.Now.AddDays(30),
                    Order = order,
                });
            }
            order.OrderDetails = new List<OrderDetails>();
            order.OrderDetails = details;
            context.Orders.Add(order);
            context.SaveChanges();

        }

        public void InsertDetails(OrderDetails orderDetails)
        {
            context.OrderDetails.Add(orderDetails);
            context.SaveChanges();
        }
    }
}
