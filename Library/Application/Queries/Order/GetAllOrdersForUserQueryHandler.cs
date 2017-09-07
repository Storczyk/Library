using Library.Application.General;
using Library.Infrastructure.Data;

namespace Library.Application.Queries.Order
{
    public class GetAllOrdersForUserQueryHandler : IQueryHandler<GetAllOrdersForUserQuery, PaginatedList<OrderQuery>>
    {
        private readonly IOrderRepository orderRepository;

        public GetAllOrdersForUserQueryHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public PaginatedList<OrderQuery> Handle(GetAllOrdersForUserQuery query)
        {
            var orders = orderRepository.GetAllOrders(query.Page < 1 ? 1 : query.Page, query.PageSize < 1 ? 10 : query.PageSize, userId:query.UserId);

            return orders;
        }
    }
}
