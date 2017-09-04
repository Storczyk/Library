using Library.Application.General;
using Library.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Queries.Order
{
    public class GetAllOrdersQueryHandler : IQueryHandler<GetAllOrdersQuery, IEnumerable<OrderQuery>>
    {
        private readonly IOrderRepository orderRepository;
        public GetAllOrdersQueryHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public IEnumerable<OrderQuery> Handle(GetAllOrdersQuery query)
        {
            return orderRepository.GetAll(query.Page < 1 ? 1 : query.Page, query.PageSize < 1 ? 10 : query.PageSize);
        }
    }
}
