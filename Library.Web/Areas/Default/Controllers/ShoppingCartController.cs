using Library.Application.Commands.Cart.AddToCart;
using Library.Application.General;
using Library.Application.Queries.Books;
using Library.Application.Queries.Books.GetBook;
using Library.DomainModel;
using Library.Web.Areas.Default.ViewModels;
using Library.Web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Areas.Default.Controllers
{
    [Area("Default")]
    public class ShoppingCartController : BaseController
    {
        private readonly ShoppingCart shoppingCart;
        public ShoppingCartController(ICommandBus commandBus, IQueryDispatcher queryDispatcher, ShoppingCart cart) : base(commandBus, queryDispatcher)
        {
            shoppingCart = cart;
        }

        public IActionResult Index()
        {
            //var cart = shoppingCart.GetCart(this.HttpContext);
            //var viewModel = new ShoppingCartViewModel()
            //{
            //    CartItems = cart.GetCartItems()
            //};
            return View();
        }

        [HttpPost]
        public IActionResult AddToCart([FromBody] AddToCartCommand addToCartCommand)
        {
            addToCartCommand.CurrentSession = HttpContext.Session;
            commandBus.Send(addToCartCommand);
            //var book = queryDispatcher.Dispatch<GetBookQuery, BookQuery>(new GetBookQuery { Id = id.ToString() });
            //var newBook = new Book
            //{
            //    Author = book.Author,
            //    BookId = Guid.Parse(book.Id),
            //    BookTitle = book.BookTitle,
            //    Description = book.Description,
            //    Ean = book.Ean,
            //    Genre = book.Genre,
            //    Isbn = book.Isbn,
            //    Pages = book.Pages,
            //    Publisher = book.Publisher,
            //    Year = book.Year,
            //};
            //var cart = shoppingCart.GetCart(this.HttpContext);
            //cart.AddToCart(newBook, HttpContext.Session);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            //var cart = shoppingCart.GetCart(this.HttpContext);
            //cart.RemoveFromCart(id);
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
