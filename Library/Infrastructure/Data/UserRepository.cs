using Library.Application.Queries.Users;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Library.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryDbContext libraryDbContext;

        public UserRepository()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server=PSROCZYK-RZE\\SQLEXPRESS;Database=libraryDB;User Id=test;Password=test;MultipleActiveResultSets=True");
            libraryDbContext = new LibraryDbContext(options.Options);
        }

        public IEnumerable<UserQuery> GetAllUsers()
        {
            return libraryDbContext.Users.Include(user => user.Orders).Select(user => new UserQuery
            {
                Username = user.UserName,
                Email = user.Email,
                UserId = user.Id,
                OrdersCount = user.Orders.Count
            }).ToList();
        }
    }
}
