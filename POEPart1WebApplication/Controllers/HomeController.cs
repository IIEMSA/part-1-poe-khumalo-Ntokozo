using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using POEPart1WebApplication.Models;

using Microsoft.AspNetCore.Mvc;

namespace POEPart1WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}

