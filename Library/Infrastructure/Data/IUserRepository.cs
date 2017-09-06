using Library.Application.Queries.Users;
using System.Collections.Generic;

namespace Library.Infrastructure.Data
{
    public interface IUserRepository
    {
        IEnumerable<UserQuery> GetAllUsers();
    }
}
