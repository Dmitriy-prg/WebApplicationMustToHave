using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using WebApplicationMustToHave.DataModels;
using WebApplicationMustToHave.Models;
using WebApplicationMustToHave.Repository;

namespace WebApplicationMustToHave.Controllers
{
    /// <summary>
    /// Контроллер персон
    /// </summary>
    /// <param name="db"></param>
    /// <param name="pm"></param>
    [Route("Person")]
    public class PersonController(IAppDbContext db, IDbPersonManager pm) : Controller
    {
        /// <summary>
        /// GET: Получить список персон
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Items")]
        public IActionResult Items()
        {
            List<IViewable> views = pm.GetPersonViewsAsync(new CancellationTokenSource().Token)!.Result;
            Console.WriteLine("AppController Items().Count = " + views?.Count);
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
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(Person? person)
        {
            if (ModelState.IsValid && person != null)
            { 
                Console.WriteLine("Create" + ControllerContext.HttpContext.Request.Path + " - " + person?.Id + " : " + person?.Name + " : " + person?.YearBirth);
                Task taskAdd = pm.AddPersonAsync((IDbPerson)person, new CancellationTokenSource().Token);
                return RedirectToAction("Items");
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
        /// <returns></returns>
        [HttpPost]
        [Route("Edit/{person?}")]
        //public ActionResult Edit(int id, IFormCollection collection)
        public ActionResult Edit(Person? person)
        {
            if (ModelState.IsValid && person != null)
            {
                //Если id = 0, то это создание
                if (person.Id == 0)
                {
                    Console.WriteLine("Create" + ControllerContext.HttpContext.Request.Path + " - " + person?.Id + " : " + person?.Name + " : " + person?.YearBirth);
                    Task taskAdd = pm.AddPersonAsync(Person.CastToObjDb(person)!, new CancellationTokenSource().Token);
                    return RedirectToAction("Items");
                }

                Console.WriteLine("Edit" + ControllerContext.HttpContext.Request.Path + " - " + person?.Id + " : " + person?.Name + " : " + person?.YearBirth);
                Task taskEdit = pm.UpdatePersonAsync((DbPerson)Person.CastToObjDb(person)!, new CancellationTokenSource().Token);
                return RedirectToAction("Items");
            }
            return NotFound();
        }

        /// <summary>
        /// GET: Удалить персону
        /// </summary>
        /// <param name="id">id персоны</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Delete/id")]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid && id > 0)
            {
                Console.WriteLine("Delete : person.Id = " + id);
                Task taskDel = pm.DeletePersonByIdAsync(id, new CancellationTokenSource().Token);
                return RedirectToAction("Items");
            }
            return NotFound();
        }
    }
}
