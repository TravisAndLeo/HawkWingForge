using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HawkWingForge.Data;

namespace HawkWingForge.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("Forge")]
        public IActionResult Forge()
        {
            return View();
        }

        [Route("Smith")]
        public IActionResult Smith()
        {
            return View();
        }

        [Route("Blades")]
        public IActionResult Blades()
        {
            return View();
        }

        [Route("Process")]
        public IActionResult Process()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
