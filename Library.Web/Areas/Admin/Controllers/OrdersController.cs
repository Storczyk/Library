using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Application.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Library.Application.Queries.Order;
using Library.Application.Commands.Order;

namespace Library.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class OrdersController : BaseController
    {
        public OrdersController(ICommandBus commandBus, IQueryDispatcher queryDispatcher) : base(commandBus, queryDispatcher)
        {
        }

        public IActionResult Index()
        {
            var orders = queryDispatcher.Dispatch<GetAllNotReturnedOrdersQuery, IEnumerable<OrderReturnQuery>>(new GetAllNotReturnedOrdersQuery { Page = 1, PageSize = 50 });
            return View(orders);
        }
        [HttpPost]
        public void BookReturment([FromBody] ReturnBookCommand returnBookCommand)
        {
            DisplayShortMessage(commandBus.Send(returnBookCommand).Result);
        } 
    }
}
