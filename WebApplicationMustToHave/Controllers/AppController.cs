using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using WebApplicationMustToHave.DataModels;
using WebApplicationMustToHave.Models;
using WebApplicationMustToHave.Repository;

namespace WebApplicationMustToHave.Controllers
{
    [Route("App")]
    public class AppController : Controller
    {
        private readonly ILogger<AppController> _logger;
        private readonly IAppDbContext _db;
        private readonly IDbCompositionManager _cm;

        //private readonly List<Film> films = new List<Film>
        //{
        //    new Film { Id = 1, Name = "Аватар", YearBirth = 2009, Type = new CompositionType { Id = 3, Name = "Фильм" } },
        //    new Film { Id = 2, Name = "Начало", YearBirth = 2010, Type = new CompositionType { Id = 3, Name = "Фильм" } }
        //};

        public AppController(IAppDbContext db, IDbCompositionManager cm, ILogger<AppController> logger)
        {
            _db = db;
            if (_db != null) Console.WriteLine("AppController() AppDbContext ID = " + ((AppDbContext)_db).ContextId);
            _cm = cm;
            if (_cm != null) Console.WriteLine("AppController() DbCompositionManager ID = " + ((DbCompositionManager)_cm).GetType());
            _logger = logger;
        }

        [HttpGet]
        [Route("Items")]
        public async Task<IActionResult> Items()
        {
            List<IViewable> views = await _cm.GetCompositionViewsAsync();
            Console.WriteLine("AppController Items().Count = " + views?.Count);
            return View(views);
        }

        [HttpPost]
        [Route("Items")]
        public IActionResult Items(string compositionId)
        {
            Console.WriteLine("compositions = " + compositionId);
            
            return RedirectToRoute("film", new { controller = "App", action = "Film", id = compositionId });
            //return View();
        }

        [HttpGet]
        [Route("Film")]
        public async Task<IActionResult> Film(int? id)
        {
            //int id = (Convert.ToInt32(RouteData.Values["id"] ?? 0));
            Console.WriteLine(ControllerContext.HttpContext.Request.Path + " - " + id);
            if (id != null)
            {
                IComposition<int, uint?, string, double>? film = Models.Film.GetObjFromDb(_cm.GetCompositionByIdAsync(Convert.ToInt32(id)).Result);
                return View(film);
            }
            return View("CreateFilm");
        }

        [HttpPost]
        [Route("Film")]
        public async Task<IActionResult> Film(Film? film)
        {
            if (film != null)
            {
                Console.WriteLine(ControllerContext.HttpContext.Request.Path + " - " + film?.Id);
                await _cm.UpdateCompositionAsync(film as IDbComposition);
                return RedirectToAction("Items");
            }
            return NotFound();
        }

        [HttpGet]
        [Route("CreateFilm")]
        public IActionResult CreateFilm()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateFilm")]
        public async Task<IActionResult> CreateFilm(Film? film)
        {
            if (film != null)
            {
                Console.WriteLine("CreateFilm" + ControllerContext.HttpContext.Request.Path + " - " + film?.Id + " : " + film?.Name + " : " + film?.YearBirth);
                film.Type = new CompositionType { Id = 3, Name = "Фильм" };
                var comp = film as Composition;
                //DbComposition composition = film as Composition;
                await _cm.AddCompositionAsync(comp as IDbComposition);
                return RedirectToAction("Items");
            }
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
