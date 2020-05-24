using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers
{
    public class UrEventsController : Controller
    {
        EventDB db = new EventDB();
        // GET: UrEvents
        public ActionResult Index()
        {
            return View(db.Tblusertenders.ToList());
        }

        // GET: UrEvents/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UrEvents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UrEvents/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UrEvents/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UrEvents/Edit/5
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

        // GET: UrEvents/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UrEvents/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
