using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMustToHave.Models;

namespace WebApplicationMustToHave.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<AppController> _logger;

        public HomeController(ILogger<AppController> logger)
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
