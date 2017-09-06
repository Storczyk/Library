using Library.Application.General;
using Library.Application.Queries.Books;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library.Web.Areas.Default.Controllers
{
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

        public IActionResult Book(GetBookQuery getBookQuery)
        {
            var book = queryDispatcher.Dispatch<GetBookQuery, BookQuery>(getBookQuery);
            return View(book);
        }

        public IActionResult SearchByTitle(SearchBooksByTitleQuery searchBooksByTitleQuery)
        {
            var books = queryDispatcher.Dispatch<SearchBooksByTitleQuery, IEnumerable<BookQuery>>(searchBooksByTitleQuery);

            return View("Index", books);
        }
    }
}
