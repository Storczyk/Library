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

        IEnumerable<Order> GetAll(int page = 1, int pageSize = 50)
        {
            if (page < 1)
            {
                page = 1;
            }
            if (pageSize < 1)
            {
                pageSize = 10;
            }

            return context.Orders.Skip(pageSize * (page - 1)).Take(pageSize).Include(i => i.Author).ToList();
        }
    }
}
