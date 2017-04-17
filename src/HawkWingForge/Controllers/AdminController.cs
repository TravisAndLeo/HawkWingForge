using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HawkWingForge.Controllers
{
    public class AdminController : Controller
    {
        [Route("/admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}