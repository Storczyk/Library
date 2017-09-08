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
        /// <summary>
        /// Gets number of avaiable book.
        /// </summary>
        /// <param name="bookId">Id of book.</param>
        int GetCurrentQuantityForBook(Guid bookId);

        /// <summary>
        /// Gets paginated list of order for user, depending on parameter which was given. Full info.
        /// </summary>
        /// <param name="page">Page Index</param>
        /// <param name="pageSize">Items per page</param>
        /// <param name="userPrincipal">User principal(Used to get logged in user)</param>
        /// <param name="userId">User Id (Used to get specific user's orders)</param>
        PaginatedList<OrderQuery> GetAllOrders(int page, int pageSize, ClaimsPrincipal userPrincipal = null, string userId = "");

        /// <summary>
        /// Gets paginated list of order for user, depending on parameter which was given. Less info.
        /// </summary>
        /// <param name="page">Page Index</param>
        /// <param name="pageSize">Items per page</param>
        /// <param name="userPrincipal">User principal(Used to get logged in user)</param>
        /// <param name="userId">User Id (Used to get specific user's orders)</param>
        PaginatedList<ShortOrderQuery> GetAllShortOrders(int page, int pageSize, ClaimsPrincipal userPrincipal = null, string userId = "");

        /// <summary>
        /// Inserts user order to database.
        /// </summary>
        /// <param name="order">This order</param>
        /// <param name="booksIds">List of books that user wants to order</param>
        /// <param name="userPrincipal">User principal(Used to get logged in user)</param>
        bool Insert(Order order, IEnumerable<string> booksIds, ClaimsPrincipal userPrincipal);

        /// <summary>
        /// Gets all not returned orders
        /// </summary>
        /// <param name="page">Page index</param>
        /// <param name="pageSize">Items per page</param>
        IEnumerable<OrderReturnQuery> GetAllNotReturnedOrders(int page = 1, int pageSize = 50);

        /// <summary>
        /// Sets an user ordered book to "returned" status
        /// </summary>
        /// <param name="orderDetailId">Specific Order Detail Id</param>
        bool BookReturment(string orderDetailId);
    }
}
