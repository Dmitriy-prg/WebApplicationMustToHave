using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using WebApplicationMustToHave.DataModels;
using WebApplicationMustToHave.Models;
using WebApplicationMustToHave.Repository;
using WebApplicationMustToHave.Services;

namespace WebApplicationMustToHave.Controllers
{
    /// <summary>
    /// Основной онтроллер
    /// </summary>
    [Route("App")]
    public class AppController : Controller
    {
        protected readonly ILoggerManager _logger;
        protected readonly IAppDbContext _db;
        protected readonly IDbCompositionManager _cm;

        //private readonly List<Film> films = new List<Film>
        //{
        //    new Film { Id = 1, Name = "Аватар", YearBirth = 2009, Type = new CompositionType { Id = 3, Name = "Фильм" } },
        //    new Film { Id = 2, Name = "Начало", YearBirth = 2010, Type = new CompositionType { Id = 3, Name = "Фильм" } }
        //};

        /// <summary>
        /// Основной контроллер
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="cm">Менеджер произведений</param>
        /// <param name="logger">логгер</param>
        public AppController(IAppDbContext db, IDbCompositionManager cm, ILoggerManager logger = null)
        {
            if (logger != null)
            {
                _logger = logger;
            }
            if (db != null)
            {
                _db = db;
            }
            if (cm != null)
            {
                _cm = cm;
            }
        }

        ///// <summary>
        ///// Get: Получить коллекцию произведений
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("Items")]
        //public async Task<IActionResult> ItemsAsync(CancellationToken cancellationToken = default)
        //{
        //    List<IViewable> views = await _cm.GetCompositionViewsAsync(cancellationToken);
        //    Console.WriteLine("AppController Items().Count = " + views?.Count);
        //    return View(views);
        //}

        //[HttpPost]
        //[Route("Items")]
        //public IActionResult Items(string compositionId)
        //{
        //    Console.WriteLine("compositions = " + compositionId);

        //    //return RedirectToRoute("film", new { controller = "App", action = "Film", id = compositionId });
        //    return View();
        //}

        //[HttpGet]
        //[Route("Film")]
        //public async Task<IActionResult> FilmAsync(int? id, CancellationToken cancellationToken = default)
        //{
        //    //int id = (Convert.ToInt32(RouteData.Values["id"] ?? 0));
        //    Console.WriteLine(ControllerContext.HttpContext.Request.Path + " - " + id);
        //    if (id != null)
        //    {
        //        await IComposition<int, uint?, string, double>? film = Models.Film.GetObjFromDb(
        //                                    _cm.GetCompositionByIdAsync(Convert.ToInt32(id), 
        //                                    cancellationToken));
        //        return View(film);
        //    }
        //    return View("CreateFilm");
        //}

        //[HttpPost]
        //[Route("Film")]
        //public async Task<IActionResult> FilmAsync(Film? film, CancellationToken cancellationToken = default)
        //{
        //    if (film != null)
        //    {
        //        Console.WriteLine(ControllerContext.HttpContext.Request.Path + " - " + film?.Id);
        //        await _cm.UpdateCompositionAsync(film as IDbComposition, cancellationToken);
        //        return RedirectToAction("Items");
        //    }
        //    return NotFound();
        //}

        //[HttpGet]
        //[Route("CreateFilm")]
        //public IActionResult CreateFilm()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[Route("CreateFilm")]
        //public async Task<IActionResult> CreateFilmAsync(Film? film, CancellationToken cancellationToken = default)
        //{
        //    if (film != null)
        //    {
        //        Console.WriteLine("CreateFilm" + ControllerContext.HttpContext.Request.Path + " - " + film?.Id + " : " + film?.Name + " : " + film?.YearBirth);
        //        film.Type = new CompositionType { Id = 3, Name = "Фильм" };
        //        var comp = film as Composition;
        //        //DbComposition composition = film as Composition;
        //        await _cm.AddCompositionAsync(comp as IDbComposition, cancellationToken);
        //        return RedirectToAction("Items");
        //    }
        //    return NotFound();
        //}
    }
}
