using Library.Application.General;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Areas
{
    public class BaseController : Controller
    {
        protected ICommandBus commandBus;
        protected IQueryDispatcher queryDispatcher;
        public BaseController(ICommandBus commandBus, IQueryDispatcher queryDispatcher)
        {
            this.commandBus = commandBus;
            this.queryDispatcher = queryDispatcher;
        }
    }
}
