using Library.Application.General;
using Library.Infrastructure.Data;

namespace Library.Application.Queries.Order
{
    public class GetAllOrdersQueryHandler : IQueryHandler<GetAllOrdersQuery, PaginatedList<OrderQuery>>
    {
        private readonly IOrderRepository orderRepository;
        public GetAllOrdersQueryHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public PaginatedList<OrderQuery> Handle(GetAllOrdersQuery query)
        {
            return orderRepository.GetAllOrders(query.Page < 1 ? 1 : query.Page, query.PageSize < 1 ? 10 : query.PageSize, userPrincipal:query.User);
        }
    }
}
