using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using WebApplicationMustToHave.DataModels;
using WebApplicationMustToHave.Models;
using WebApplicationMustToHave.Repository;

namespace WebApplicationMustToHave.Controllers
{
    public class AppController : Controller
    {
        private readonly ILogger<AppController> _logger;
        private readonly AppDbContext _db;

        //private readonly List<Film> films = new List<Film>
        //{
        //    new Film { Id = 1, Name = "Аватар", YearBirth = 2009, Type = new CompositionType { Id = 3, Name = "Фильм" } },
        //    new Film { Id = 2, Name = "Начало", YearBirth = 2010, Type = new CompositionType { Id = 3, Name = "Фильм" } },
        //    new Film { Id = 3, Name = "Generation P", Type = new CompositionType { Id = 3, Name = "Фильм" } }
        //};

        public AppController(AppDbContext db, ILogger<AppController> logger)
        {
            _db = db;
            if (_db != null) Console.WriteLine("AppController() AppDbContext ID = " + _db.ContextId);
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Items()
        {
            List<IViewable> views = await new DbCompositionManager(_db)?.GetCompositionViewsAsync();
            Console.WriteLine("AppController Items().Count = " + views?.Count);
            return View(views);
            //return View(films);
        }

        [HttpPost]
        public IActionResult Items(string compositionId)
        {
            Console.WriteLine("compositions = " + compositionId);
            
            return RedirectToRoute("film", new { controller = "App", action = "Film", id = compositionId });
            //return View();
        }

        [HttpGet]
        public async Task<IActionResult> Film(int? id)
        {
            //int id = (Convert.ToInt32(RouteData.Values["id"] ?? 0));
            Console.WriteLine(ControllerContext.HttpContext.Request.Path + " - " + id);
            if (id != null)
            {
                IComposition<int, uint?, string, double>? film = Models.Film.GetObjFromDb(new DbCompositionManager(_db)?.GetCompositionByIdAsync(Convert.ToInt32(id)).Result);
                return View(film);
            }
            return View("CreateFilm");
        }

        [HttpPost]
        public async Task<IActionResult> Film(Film? film)
        {
            if (film != null)
            {
                Console.WriteLine(ControllerContext.HttpContext.Request.Path + " - " + film?.Id);
                await new DbCompositionManager(_db)?.UpdateCompositionAsync(film as IDbComposition);
                return RedirectToAction("Items");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult CreateFilm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFilm(Film? film)
        {
            if (film != null)
            {
                Console.WriteLine("CreateFilm" + ControllerContext.HttpContext.Request.Path + " - " + film?.Id + " : " + film?.Name + " : " + film?.YearBirth);
                film.Type = new CompositionType { Id = 3, Name = "Фильм" };
                var comp = film as Composition;
                //DbComposition composition = film as Composition;
                await new DbCompositionManager(_db)?.AddCompositionAsync(comp as IDbComposition);
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
