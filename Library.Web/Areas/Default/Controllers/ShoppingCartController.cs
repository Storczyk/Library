using Library.Application.Commands.Cart;
using Library.Application.General;
using Library.Application.Queries.Books;
using Library.Application.Queries.Cart;
using Library.Application.Queries.Order;
using Library.Web.Areas.Default.ViewModels;
using Library.Web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Library.Web.Areas.Default.Controllers
{
    [Area("Default")]
    public class ShoppingCartController : BaseController
    {
        public ShoppingCartController(ICommandBus commandBus, IQueryDispatcher queryDispatcher) : base(commandBus, queryDispatcher) { }

        public IActionResult Index()
        {
            var books = queryDispatcher.Dispatch<GetBooksFromCartQuery, IEnumerable<BookQuery>>(new GetBooksFromCartQuery { CurrentSession = this.HttpContext.Session });
            var orderViewModel = new OrderQuery { Books = books };

            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult AddToCart([FromBody] AddToCartCommand addToCartCommand)
        {
            addToCartCommand.CurrentSession = HttpContext.Session;
            commandBus.Send(addToCartCommand);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(RemoveFromCartCommand removeFromCartCommand)
        {
            removeFromCartCommand.CurrentSession = HttpContext.Session;
            commandBus.Send(removeFromCartCommand);
            return Ok();
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(int id)
        {
            return View();
        }
    }
}
