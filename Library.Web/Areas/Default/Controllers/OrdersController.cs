using Library.Application.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Library.Application.Queries.Order;
using Library.Application.Queries;
using Library.Application.Commands.Books;

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
            var query = new GetAllShortOrdersForUserQuery
            {               
                Page = page,
                PageSize = pageSize,
                User = User
            };
            var orders = queryDispatcher.Dispatch<GetAllShortOrdersForUserQuery, PaginatedList<ShortOrderQuery>>(query);

            return View(orders);
        }

        [HttpPost]
        public void RateBook([FromBody]RateBookCommand rateBookCommand)
        {
            rateBookCommand.User = User;
            var response = commandBus.Send(rateBookCommand);
            DisplayShortMessage(response.Result);
        }
    }
}
