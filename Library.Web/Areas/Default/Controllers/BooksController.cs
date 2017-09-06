using Library.Application.General;
using Library.Application.Queries;
using Library.Application.Queries.Books;
using Library.DomainModel.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library.Web.Areas.Default.Controllers
{
    public class BooksController : BaseController
    {
        public BooksController(ICommandBus commandBus, IQueryDispatcher queryDispatcher) : base(commandBus, queryDispatcher)
        {
        }

        public IActionResult Index(int page, string BookTitle, Genre genre)
        {
            var getAllBooksQuery = new GetAllBooksQuery { Page = page };
            var books = queryDispatcher.Dispatch<GetAllBooksQuery, PaginatedList<BookQuery>>(getAllBooksQuery);
            return View(books);
        }

        public IActionResult Book(GetBookQuery getBookQuery)
        {
            var book = queryDispatcher.Dispatch<GetBookQuery, BookQuery>(getBookQuery);
            return View(book);
        }

        public IActionResult SearchByTitle(SearchBooksByTitleQuery searchBooksByTitleQuery)
        {
            var books = queryDispatcher.Dispatch<SearchBooksByTitleQuery, PaginatedList<BookQuery>>(searchBooksByTitleQuery);

            return View("Index", books);
        }

        public IActionResult GetByGenre(GetBooksByGenreQuery getBooksByGenreQuery)
        {
            var books = queryDispatcher.Dispatch<GetBooksByGenreQuery, PaginatedList<BookQuery>>(getBooksByGenreQuery);

            return View("Index", books);
        }
    }
}
