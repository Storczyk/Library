using Library.Application.Commands.Cart;
using Library.Application.Commands.Order;
using Library.Application.General;
using Library.Application.Queries.Books;
using Library.Application.Queries.Cart;
using Library.Application.Queries.Order;
using Library.DomainModel;
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
            DisplayShortMessage(commandBus.Send(addToCartCommand).Result);
        }

        [Route("[controller]/[action]")]
        [HttpPost]
        public void RemoveFromCart([FromBody] RemoveFromCartCommand removeFromCartCommand)
        {
            removeFromCartCommand.CurrentSession = HttpContext.Session;
            DisplayShortMessage(commandBus.Send(removeFromCartCommand).Result);
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
            var books = queryDispatcher.Dispatch<GetBooksFromCartQuery, IEnumerable<BookQuery>>(new GetBooksFromCartQuery { CurrentSession = this.HttpContext.Session });
            var order = new OrderQuery { Books = books };

            return View(order);
        }

        [Authorize]
        [Route("[controller]/[action]")]
        [HttpPost]
        public IActionResult Checkout(CreateOrderCommand createOrderCommand)
        {            
            createOrderCommand.User = this.User;
            createOrderCommand.Session = HttpContext.Session;
            createOrderCommand.BooksIds = queryDispatcher.Dispatch<GetBooksIdsFromCartQuery, IEnumerable<string>>(
                new GetBooksIdsFromCartQuery { CurrentSession = HttpContext.Session });

            DisplayShortMessage(commandBus.Send(createOrderCommand).Result);
            
            return RedirectToAction("Index");
        }
    }
}
