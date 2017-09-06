using Library.Application.Logger;
using Library.Application.Queries;
using Library.Application.Queries.Books;
using Library.Application.Queries.Order;
using Library.DomainModel;
using Library.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Library.Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LibraryDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public OrderRepository(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server=PSROCZYK-RZE\\SQLEXPRESS;Database=libraryDB;User Id=test;Password=test;MultipleActiveResultSets=True");
            context = new LibraryDbContext(options.Options);
        }

        public int GetCurrentQuantityForBook(Guid bookId)
        {
            return context.OrderDetails.Where(x => !x.IsBookReturned && x.BookId == bookId).Count();
        }

        public PaginatedList<OrderQuery> GetAllOrders(int page, int pageSize)
        {
            return PaginatedList<OrderQuery>.Create(context.Orders.Include(i => i.User).Include(i => i.OrderDetails).Select(i => new OrderQuery
            {
                Address = i.Address,
                PhoneNumber = i.PhoneNumber,
                OrderDate = i.OrderDate,
                Books = i.OrderDetails.Select(j => new BookShortQuery
                {
                    Id = j.Book.BookId.ToString(),
                    BookTitle = j.Book.BookTitle,
                    Author = j.Book.Author,
                    Description = j.Book.Description,
                    Genre = j.Book.Genre,
                })
            }).AsQueryable(), page, pageSize);
        }

        public PaginatedList<OrderQuery> GetAllOrders(string userId, int page, int pageSize)
        {
            return PaginatedList<OrderQuery>.Create(context.Orders.Where(i => i.UserId == userId)
                .Include(i => i.User).Include(i => i.OrderDetails)
                .Select(i => new OrderQuery
                {
                    Address = i.Address,
                    PhoneNumber = i.PhoneNumber,
                    OrderDate = i.OrderDate,
                    Books = i.OrderDetails.Select(j => new BookShortQuery
                    {
                        Id = j.Book.BookId.ToString(),
                        BookTitle = j.Book.BookTitle,
                        Author = j.Book.Author,
                        Description = j.Book.Description,
                        Genre = j.Book.Genre,
                    })
                }), page, pageSize);
        }

        public bool Insert(Order order, IEnumerable<string> booksIds, ClaimsPrincipal userPrincipal)
        {
            try
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
                        IsBookReturned = false
                    });
                }
                var userId = userManager.GetUserId(userPrincipal);
                order.User = context.Users.Find(userId);
                order.UserId = userId;
                order.OrderDetails = new List<OrderDetails>();
                order.OrderDetails = details;
                context.Orders.Add(order);
                if (context.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception exception)
            {
                Logger.Log(exception.Message);
                return false;
            }
        }

        public IEnumerable<OrderReturnQuery> GetAllNotReturnedOrders(int page = 1, int pageSize = 50)
        {
            var orders = context.OrderDetails.Where(i => !i.IsBookReturned).Select(i => new OrderReturnQuery
            {
                UserEmail = i.Order.User.Email,
                UserId = i.Order.UserId,
                Order = new OrderDetailQuery
                {
                    Book = new BookShortQuery
                    {
                        Author = i.Book.Author,
                        BookTitle = i.Book.BookTitle,
                        Description = i.Book.Description,
                        Genre = i.Book.Genre,
                        Id = i.Book.BookId.ToString(),
                    },
                    OrderDetailId = i.OrderDetailId,
                    OrderId = i.OrderId,
                    ReturnDate = i.ReturnDate,
                }
            }).ToList();
            return orders;
        }

        public bool BookReturment(string orderDetailId)
        {
            try
            {
                var orderDetail = context.OrderDetails.FirstOrDefault(i => i.OrderDetailId == Guid.Parse(orderDetailId));
                orderDetail.IsBookReturned = true;
                orderDetail.ReturnDate = DateTime.Now;
                if (context.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception exception)
            {
                Logger.Log(exception.Message);
                return false;
            }
        }
    }
}
