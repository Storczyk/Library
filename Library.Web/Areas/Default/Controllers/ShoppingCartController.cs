using Library.Application.Commands.Cart;
using Library.Application.General;
using Library.Application.Queries.Books;
using Library.Application.Queries.Cart;
using Library.Application.Queries.Order;
<<<<<<< HEAD
using Library.Web.Areas.Default.ViewModels;
using Library.Web.Extensions;
=======
>>>>>>> c11fede6ec67dde7c8eec4922935efaabfb6c406
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Library.Web.Areas.Default.Controllers
{

    public class ShoppingCartController : BaseController
    {
        public ShoppingCartController(ICommandBus commandBus, IQueryDispatcher queryDispatcher) : base(commandBus, queryDispatcher) { }

        public IActionResult Index()
        {
            var books = queryDispatcher.Dispatch<GetBooksFromCartQuery, IEnumerable<BookQuery>>(new GetBooksFromCartQuery { CurrentSession = this.HttpContext.Session });
            var orderViewModel = new OrderQuery { Books = books };

            return View(orderViewModel);
        }

        [Route("[controller]/[action]")]
        [HttpPost]
        public void AddToCart([FromBody] AddToCartCommand addToCartCommand)
        {
            addToCartCommand.CurrentSession = HttpContext.Session;
            commandBus.Send(addToCartCommand);
        }
        [Route("[controller]/[action]")]
        [HttpPost]
        public void RemoveFromCart([FromBody] RemoveFromCartCommand removeFromCartCommand)
        {
            removeFromCartCommand.CurrentSession = HttpContext.Session;
            commandBus.Send(removeFromCartCommand);
        }

        [Route("[controller]/[action]")]
        [HttpGet]
        public int HowManyItemsInCart()
        {
            return HttpContext.Session.Keys.Count(i => i.Contains("cart_"));
        }

        [Authorize]
        [Route("[controller]/[action]")]
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [Authorize]
        [Route("[controller]/[action]")]
        [HttpPost]
        public IActionResult Checkout(int id)
        {
            return View();
        }
    }
}
