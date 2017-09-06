using Library.Application.Queries;
using Library.Application.Queries.Order;
using Library.DomainModel;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Library.Infrastructure.Data
{
    public interface IOrderRepository
    {
        PaginatedList<OrderQuery> GetAllOrders(int page = 1, int pageSize = 50);

        PaginatedList<OrderQuery> GetAllOrders(string userId, int page = 1, int pageSize = 50);

        bool Insert(Order order, IEnumerable<string> booksIds, ClaimsPrincipal userPrincipal);

        int GetCurrentQuantityForBook(Guid bookId);

        IEnumerable<OrderReturnQuery> GetAllNotReturnedOrders(int page = 1, int pageSize = 50);

        bool BookReturment(string orderDetailId);
    }
}
