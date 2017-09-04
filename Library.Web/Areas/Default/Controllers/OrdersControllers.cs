using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Application.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Library.Application.Queries.Order;

namespace Library.Web.Areas.Default.Controllers
{
    [Authorize]
    public class OrdersControllers : BaseController
    {
        public OrdersControllers(ICommandBus commandBus, IQueryDispatcher queryDispatcher) : base(commandBus, queryDispatcher)
        {
        }

        [Route("[controller]/[action]")]
        public IActionResult Index()
        {
            
            return View(queryDispatcher.Dispatch<GetAllOrdersQuery,IEnumerable<OrderQuery>>(new GetAllOrdersQuery { Page = 1, PageSize = 10}));
        }
    }
}
