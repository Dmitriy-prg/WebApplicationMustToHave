using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMustToHave.Models;
using WebApplicationMustToHave.Services;

namespace WebApplicationMustToHave.Controllers
{
    public class HomeController : Controller
    {
        protected readonly ILoggerManager _logger;

        public HomeController(ILoggerManager logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
