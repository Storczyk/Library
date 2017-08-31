using Library.Application.General;
using Library.Application.Queries.Books;
using Library.Application.Queries.Books.GetAllBooks;
using Library.Web.Areas;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library.Web.Areas.Default.Controllers
{
    [Area("Default")]
    public class BooksController : BaseController
    {
        public BooksController(ICommandBus commandBus, IQueryDispatcher queryDispatcher) : base(commandBus, queryDispatcher)
        {
        }

        public IActionResult Index()
        {
            var getAllBooksQuery = new GetAllBooksQuery();
            var books = queryDispatcher.Dispatch<GetAllBooksQuery, IEnumerable<BookQuery>>(getAllBooksQuery);
            return View(books);
        }
    }
}
