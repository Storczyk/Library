using Library.Application.General;
using System.Collections.Generic;

namespace Library.Application.Queries.Order
{
    public class GetAllNotReturnedOrdersQuery:IQuery<IEnumerable<OrderReturnQuery>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
