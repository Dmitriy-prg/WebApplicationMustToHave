using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMustToHave.DataModels;
using WebApplicationMustToHave.Models;
using WebApplicationMustToHave.Repository;

namespace WebApplicationMustToHave.Controllers
{
    public class PersonController(AppDbContext db) : Controller
    {
        private readonly AppDbContext _db = db;

        // GET: PersonController
        public ActionResult Items()
        {
            return View();
        }

        //// GET: PersonController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View("Edit");
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        public ActionResult Create(Person? person)
        {
            try
            {
                if (ModelState.IsValid && person != null)
                { 
                    Console.WriteLine("Create" + ControllerContext.HttpContext.Request.Path + " - " + person?.Id + " : " + person?.Name + " : " + person?.YearBirth);
                    Task taskAdd = new DbPersonManager(_db).AddPersonAsync((IDbPerson<uint, uint?>)person);
                    //return RedirectToAction(nameof(Index));
                    return RedirectToAction("Items");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        public ActionResult Edit(Person? person)
        {
            if (ModelState.IsValid && person != null)
            {
                if (person.Id == 0)
                {
                    Console.WriteLine("Create" + ControllerContext.HttpContext.Request.Path + " - " + person?.Id + " : " + person?.Name + " : " + person?.YearBirth);
                    Task taskAdd = new DbPersonManager(_db).AddPersonAsync((IDbPerson<uint, uint?>)person);
                    //return RedirectToAction(nameof(Index));
                    return RedirectToAction("Items");
                }

                try
                {
                    Console.WriteLine("Edit" + ControllerContext.HttpContext.Request.Path + " - " + person.Id);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return NotFound();
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
