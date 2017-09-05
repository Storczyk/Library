using Library.Application.Queries.Order;
using Library.DomainModel;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Library.Infrastructure.Data
{
    public interface IOrderRepository
    {
        IEnumerable<OrderQuery> GetAllOrders(int page = 1, int pageSize = 50);

        void Insert(Order order, IEnumerable<string> booksIds, ClaimsPrincipal userPrincipal);

        int GetCurrentQuantityForBook(Guid bookId);
    }
}
