using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMustToHave.DataModels;
using WebApplicationMustToHave.Models;
using WebApplicationMustToHave.Repository;

namespace WebApplicationMustToHave.Controllers
{
    [Route("Person")]
    public class PersonController(IAppDbContext db, IDbPersonManager pm) : Controller
    {
        [HttpGet]
        [Route("Items")]
        public async Task<IActionResult> Items()
        {
            List<IViewable> views = await pm?.GetPersonViewsAsync()!;
            Console.WriteLine("AppController Items().Count = " + views?.Count);
            return View(views);
            //return View();
        }

        //// GET: PersonController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            return View("Edit");
        }

        // POST: PersonController/Create
        [HttpPost]
        [Route("Create")]
        //public ActionResult Create(IFormCollection collection)
        public async Task<ActionResult> Create(Person? person)
        {
            if (ModelState.IsValid && person != null)
            { 
                Console.WriteLine("Create" + ControllerContext.HttpContext.Request.Path + " - " + person?.Id + " : " + person?.Name + " : " + person?.YearBirth);
                await pm.AddPersonAsync((IDbPerson)person);
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Items");
            }
            return View();
        }

        [HttpGet]
        [Route("Edit/{id?}")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [Route("Edit/{person?}")]
        //public ActionResult Edit(int id, IFormCollection collection)
        public ActionResult Edit(Person? person)
        {
            if (ModelState.IsValid && person != null)
            {
                if (person.Id == 0)
                {
                    Console.WriteLine("Create" + ControllerContext.HttpContext.Request.Path + " - " + person?.Id + " : " + person?.Name + " : " + person?.YearBirth);
                    Task taskAdd = pm.AddPersonAsync(Person.CastToObjDb(person)!);
                    //return RedirectToAction(nameof(Index));
                    return RedirectToAction("Items");
                }

                Console.WriteLine("Edit" + ControllerContext.HttpContext.Request.Path + " - " + person.Id);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        [HttpGet]
        [Route("Delete/id")]
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
