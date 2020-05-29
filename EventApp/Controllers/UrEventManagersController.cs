using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers
{
    public class UrEventManagersController : Controller
    {
        EventDB db = new EventDB();
        // GET: UrEventManagers
        public ActionResult Index()
        {
            if (Session["uid"] != null)
                return View(db.Tbleventmanagers.ToList()) ;
            else
                return RedirectToAction("Index", "UrLogin");
        }

        // GET: UrEventManagers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UrEventManagers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UrEventManagers/Create
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

        // GET: UrEventManagers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UrEventManagers/Edit/5
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

        // GET: UrEventManagers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UrEventManagers/Delete/5
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
