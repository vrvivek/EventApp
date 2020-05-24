using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers
{
    public class UrClientProfileController : Controller
    {
        // GET: UrClientProfile
        public ActionResult Index()
        {
            return View();
        }

        // GET: UrClientProfile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UrClientProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UrClientProfile/Create
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

        // GET: UrClientProfile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UrClientProfile/Edit/5
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

        // GET: UrClientProfile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UrClientProfile/Delete/5
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
