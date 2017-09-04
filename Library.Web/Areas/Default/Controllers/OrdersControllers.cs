using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Application.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
            return View();
        }
    }
}
