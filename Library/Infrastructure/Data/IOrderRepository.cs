using Library.Application.Queries.Order;
using Library.DomainModel;
using System.Collections.Generic;

namespace Library.Infrastructure.Data
{
    public interface IOrderRepository
    {
        IEnumerable<OrderQuery> GetAll(int page, int pageSize);
    }
}
