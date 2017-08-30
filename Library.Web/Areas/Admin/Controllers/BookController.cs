using Library.Application.Commands.AddBook;
using Library.Application.Commands.EditBook;
using Library.Application.General;
using Library.Application.Queries;
using Library.Application.Queries.GetAllBooks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class BookController : BaseController
    {
        public BookController(ICommandBus commandBus, IQueryDispatcher queryDispatcher) : base(commandBus, queryDispatcher) { }

        [HttpGet]
        public IActionResult Index()
        {
            //var query = new GetAllBooksQuery();
            //var books = queryDispatcher.Dispatch<GetAllBooksQuery, IEnumerable<BookQuery>>(query);
            List<BookQuery> books = new List<BookQuery>
            {
                new BookQuery
                {
                    BookTitle = "title",
                    Author = "authot",
                    Ean = 12,
                    Id = 0,
                    Isbn = 4231,
                    Pages = 14,
                    Publisher = "publisher",
                    Year = 2012
                },
                new BookQuery
                {
                         BookTitle = "title",
                    Author = "authot",
                    Ean = 12,
                    Id = 1,
                    Isbn = 4231,
                    Pages = 14,
                    Publisher = "publisher",
                    Year = 2012
                },
                new BookQuery
                {
                                BookTitle = "title",
                    Author = "authot",
                    Ean = 12,
                    Id = 2,
                    Isbn = 4231,
                    Pages = 14,
                    Publisher = "publisher",
                    Year = 2012
                },
                new BookQuery
                {
                                        BookTitle = "title",
                    Author = "authot",
                    Ean = 12,
                    Id = 3,
                    Isbn = 4231,
                    Pages = 14,
                    Publisher = "publisher",
                    Year = 2012
                },
                new BookQuery
                {
                                        BookTitle = "title",
                    Author = "authot",
                    Ean = 12,
                    Id = 4,
                    Isbn = 4231,
                    Pages = 14,
                    Publisher = "publisher",
                    Year = 2012
                }
            };
            return View(books);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddBookCommand addBookCommand)
        {
            if (ModelState.IsValid)
            {
                commandBus.Send(addBookCommand);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //var book = queryDispatcher.Dispatch<>();
            //return View(book);

            return View();
        }

        [HttpPost]
        public IActionResult Edit(EditBookCommand editBookCommand)
        {
            if (ModelState.IsValid)
            {
                commandBus.Send(editBookCommand);
            }

            return RedirectToAction("Index");
        }
    }
}
