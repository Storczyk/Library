using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Infrastructure.Areas.Default.Controllers
{
    [Area("Default")]
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
