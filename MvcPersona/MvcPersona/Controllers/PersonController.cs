using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPersona.Models;

namespace MvcPersona.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {

            if (Session["People"] == null)
            {
                List<Person> people = new List<Person>();
                people.Add(new Person { ID = 01,FirstName = "Gustavo", LastName = "Negro", BirthDay = "01/01/01", IsTecsup = true});
                people.Add(new Person { ID = 02, FirstName = "Gustavo", LastName = "Negro", BirthDay = "01/01/01", IsTecsup = true});
                Session["People"] = people;
            }

            return View(Session["People"]);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(Person model)
        {
            try
            {
                if (Session["People"] == null)
                    Session["People"] = new List<Person>();
                // TODO: Add insert logic here
                ((List<Person>)Session["People"]).Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {

            var model = ((List<Person>)Session["People"]).Where(x => x.ID == id).FirstOrDefault();

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = ((List<Person>)Session["People"]).Where(x => x.ID == id).FirstOrDefault();

            return View(model);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            var model = ((List<Person>)Session["People"]).Where(x => x.ID == id).FirstOrDefault();

            return View(model);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Person model)
        {
            try
            {
                //TODO: Add delete logic here
                ((List<Person>)Session["People"]).Remove(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}