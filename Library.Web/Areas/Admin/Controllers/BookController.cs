using Library.Application.Commands.AddBook;
using Library.Application.General;
using Library.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BookCommand bookCommand)
        {
            var addBookCommand = new AddBookCommand
            {
                Author = bookCommand.Author,
                BookTitle = bookCommand.BookTitle,
                Ean = bookCommand.Ean,
                Isbn = bookCommand.Isbn,
                Pages = bookCommand.Pages,
                Publisher = bookCommand.Publisher,
                Year = bookCommand.Year
            };

            commandBus.Send(addBookCommand);
            return RedirectToAction("Index");
        }
    }
}
