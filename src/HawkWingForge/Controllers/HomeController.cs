using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HawkWingForge.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Forge()
        {
            return View();
        }

        public IActionResult Smith()
        {
            return View();
        }

        public IActionResult Blades()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
