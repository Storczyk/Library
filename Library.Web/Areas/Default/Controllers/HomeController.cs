using Microsoft.AspNetCore.Mvc;

namespace Library.Infrastructure.Areas.Default.Controllers
{
    [Area("Default")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
