using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using WebApplicationMustToHave.DataModels;
using WebApplicationMustToHave.Models;
using WebApplicationMustToHave.Repository;
using WebApplicationMustToHave.Services;

namespace WebApplicationMustToHave.Controllers
{
    /// <summary>
    /// Контроллер персон
    /// </summary>
    /// <param name="db"></param>
    /// <param name="pm"></param>
    [Route("Person")]
    public class PersonController : Controller
    {
        protected readonly ILoggerManager _logger;
        protected readonly IAppDbContext _db;
        protected readonly IDbPersonManager _pm;

        /// <summary>
        /// Контроллер
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="cm">Менеджер произведений</param>
        /// <param name="logger">логгер</param>
        public PersonController(IAppDbContext db, IDbPersonManager pm, ILoggerManager logger = null)
        {
            if (logger != null)
            {
                _logger = logger;
            }
            if (db != null)
            {
                _db = db;
            }
            if (pm != null)
            {
                _pm = pm;
            }
        }

        /// <summary>
        /// GET: Получить список персон
        /// </summary>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Items")]
        public async Task<IActionResult> ItemsAsync(CancellationToken cancellationToken = default)
        {
            List<IViewable> views = await _pm.GetPersonViewsAsync(cancellationToken);
            _logger.LogInformation("AppController Items().Count = " + views?.Count); 
            return View(views);
        }

        //// GET: PersonController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        /// <summary>
        /// GET: Создать персону
        /// </summary>
        /// <returns>представление Edit</returns>
        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            return View("Edit");
        }

        /// <summary>
        /// POST: Создать персону
        /// </summary>
        /// <param name="person">персона</param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> CreateAsync(Person? person, CancellationToken cancellationToken = default)
        {
            if (person != null)
            {
                _logger.LogInformation("Create" + ControllerContext.HttpContext.Request.Path + " - " + person?.Id + " : " + person?.Name + " : " + person?.YearBirth);
                await _pm.AddPersonAsync(Person.CastToObjDb(person)!, cancellationToken);
                return RedirectToAction("ItemsAsync");
            }
            return View();
        }

        /// <summary>
        /// GET: Создать персону
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: PersonController/Edit/5
        [HttpGet]
        [Route("Edit/{id?}")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonController/Edit/5
        /// <summary>
        /// POST: Редактировать персону
        /// </summary>
        /// <param name="person">персона</param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Edit/{person?}")]
        //public ActionResult Edit(int id, IFormCollection collection)
        public async Task<ActionResult> EditAsync(Person? person, CancellationToken cancellationToken = default)
        {
            if (person != null)
            {
                //Если id = 0, то это создание
                if (person.Id == 0)
                {
                    _logger.LogInformation("Create" + ControllerContext.HttpContext.Request.Path + " - " + person?.Id + " : " + person?.Name + " : " + person?.YearBirth);
                    await _pm.AddPersonAsync(Person.CastToObjDb(person)!, cancellationToken);
                    return RedirectToAction("Items");
                }

                _logger.LogInformation("Edit" + ControllerContext.HttpContext.Request.Path + " - " + person?.Id + " : " + person?.Name + " : " + person?.YearBirth);
                await _pm.UpdatePersonAsync((DbPerson)Person.CastToObjDb(person)!, cancellationToken);
                return RedirectToAction("Items");
            }
            return NotFound();
        }

        /// <summary>
        /// GET: Удалить персону
        /// </summary>
        /// <param name="id">id персоны</param>
        /// <param name="cancellationToken">токен отмены</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Delete/id")]
        public ActionResult Delete(int id, CancellationToken cancellationToken = default)
        {
            if (id > 0)
            {
                _logger.LogInformation("Delete : person.Id = " + id);
                Task taskDel = _pm.DeletePersonByIdAsync(id, cancellationToken);
                return RedirectToAction("ItemsAsync");
            }
            return NotFound();
        }
    }
}
