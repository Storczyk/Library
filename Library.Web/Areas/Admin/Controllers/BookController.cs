using Library.Application.Commands.AddBook;
using Library.Application.Commands.DeleteBook;
using Library.Application.Commands.EditBook;
using Library.Application.General;
using Library.Application.Queries;
using Library.Application.Queries.GetAllBooks;
using Library.Application.Queries.GetBook;
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
            if (ModelState.IsValid)
            {
                commandBus.Send(addBookCommand);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(GetBookQuery getBookQuery)
        {
            //var book = queryDispatcher.Dispatch<GetBookQuery, BookQuery>(getBookQuery);
            var book = new BookQuery();
            book.BookTitle = "Title";
            book.Year = 1223;
            book.Description = "sqwd";
            book.Pages = 17;
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete([FromBody] DeleteBookCommand deleteBookCommand)
        {
            if (ModelState.IsValid)
            {
                //commandBus.Send(deleteBookCommand);
            }
            return Ok("Deleted");
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
