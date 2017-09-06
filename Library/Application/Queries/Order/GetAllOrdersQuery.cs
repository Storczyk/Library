using Library.Application.General;
using System.Collections.Generic;

namespace Library.Application.Queries.Order
{
    public class GetAllOrdersQuery : IQuery<IEnumerable<OrderQuery>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
