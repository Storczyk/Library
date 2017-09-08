using Library.Application.General;
using System.Security.Claims;

namespace Library.Application.Queries.Order
{
    public class GetAllShortOrdersForUserQuery : IQuery<PaginatedList<ShortOrderQuery>>
    {
        public ClaimsPrincipal User { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
