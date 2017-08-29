using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Areas.Admin.Controllers
{
    public class BookController : BaseController
    {
        public BookController() : base() { }

        public IActionResult Add()
        {
            return View();
        }
    }
}
