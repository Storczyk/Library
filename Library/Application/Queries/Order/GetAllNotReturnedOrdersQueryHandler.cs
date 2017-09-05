using Library.Application.General;
using Library.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Queries.Order
{
    public class GetAllNotReturnedOrdersQueryHandler : IQueryHandler<GetAllNotReturnedOrdersQuery, IEnumerable<OrderReturnQuery>>
    {
        private readonly IOrderRepository orderRepository;
        public GetAllNotReturnedOrdersQueryHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public IEnumerable<OrderReturnQuery> Handle(GetAllNotReturnedOrdersQuery query)
        {
            return orderRepository.GetAllNotReturnedOrders();
        }
    }
}
