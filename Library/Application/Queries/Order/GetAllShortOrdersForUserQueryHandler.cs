using Library.Application.General;
using Library.Infrastructure.Data;
using System;

namespace Library.Application.Queries.Order
{
    class GetAllShortOrdersForUserQueryHandler : IQueryHandler<GetAllShortOrdersForUserQuery, PaginatedList<ShortOrderQuery>>
    {
        private readonly IOrderRepository orderRepository;

        public GetAllShortOrdersForUserQueryHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public PaginatedList<ShortOrderQuery> Handle(GetAllShortOrdersForUserQuery query)
        {
            var orders = orderRepository.GetAllShortOrders(query.Page, query.PageSize, query.User);

            return orders;
        }
    }
}
