using Library.Application.General;

namespace Library.Application.Queries.Order
{
    public class GetAllOrdersForUserQuery : IQuery<PaginatedList<OrderQuery>>
    {
        public string UserId { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
