using Library.Application.Commands.Books;
using Library.Application.General;
using Library.Application.Queries.Books;
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
            var query = new GetAllBooksQuery();
            var books = queryDispatcher.Dispatch<GetAllBooksQuery, IEnumerable<BookQuery>>(query);
            
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
            if (!ModelState.IsValid)
            {
                return View();
            }

            DisplayShortMessage(commandBus.Send(addBookCommand).Result);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(GetBookQuery getBookQuery)
        {
            var book = queryDispatcher.Dispatch<GetBookQuery, BookQuery>(getBookQuery);

            return View(book);
        }

        [HttpPost]
        public void Delete([FromBody]DeleteBookCommand deleteBookCommand)
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            DisplayShortMessage(commandBus.Send(deleteBookCommand).Result);
        }

        [HttpPost]
        public IActionResult Edit(EditBookCommand editBookCommand)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            DisplayShortMessage(commandBus.Send(editBookCommand).Result);
            return RedirectToAction("Index");
        }
    }
}
