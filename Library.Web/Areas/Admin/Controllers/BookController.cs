using Library.Application.Commands.AddBook;
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
                    
                },
                new BookQuery
                {

                },
                new BookQuery
                {

                },
                new BookQuery
                {

                },
                new BookQuery
                {

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
    }
}
