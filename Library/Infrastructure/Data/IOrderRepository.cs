using Library.DomainModel;
using System.Collections.Generic;

namespace Library.Infrastructure.Data
{
    interface IOrderRepository
    {
        IEnumerable<Order> GetAll(int page = 1, int pageSize = 50);
    }
}
