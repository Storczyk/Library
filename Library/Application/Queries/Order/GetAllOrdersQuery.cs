using Library.Application.General;
using System.Security.Claims;

namespace Library.Application.Queries.Order
{
    public class GetAllOrdersQuery : IQuery<PaginatedList<OrderQuery>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
