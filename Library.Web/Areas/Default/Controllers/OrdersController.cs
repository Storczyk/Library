using Library.Application.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Library.Application.Queries.Order;
using Library.Application.Queries;

namespace Library.Web.Areas.Default.Controllers
{
    [Authorize]
    public class OrdersController : BaseController
    {
        public OrdersController(ICommandBus commandBus, IQueryDispatcher queryDispatcher) : base(commandBus, queryDispatcher)
        {
        }

        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            var query = new GetAllOrdersQuery
            {
                Page = page,
                PageSize = pageSize,
                User = User
            };
            return View(queryDispatcher.Dispatch<GetAllOrdersQuery,PaginatedList<OrderQuery>>(query));
        }
    }
}
