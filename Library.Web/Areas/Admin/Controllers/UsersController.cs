using Library.Application.General;
using Library.Application.Queries.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class UsersController : BaseController
    {
        public UsersController(ICommandBus commandBus, IQueryDispatcher queryDispatcher) : base(commandBus, queryDispatcher)
        {
        }

        public IActionResult Index()
        {
            var users = queryDispatcher.Dispatch<GetAllUsersQuery, IEnumerable<UserQuery>>(new GetAllUsersQuery());

            return View(users);
        }

        public void GetOrders(string userId)
        {

        }
    }
}
