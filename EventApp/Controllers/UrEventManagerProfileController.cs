using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers
{
    public class UrEventManagerProfileController : Controller
    {
        EventDB db = new EventDB();
        // GET: UrEventManagerProfile
        public ActionResult Index()
        {
            if (Session["uid"] != null)
            {
                int id = Convert.ToInt32(Session["mid"]);
                return View(db.Tbleventmanagers.SingleOrDefault(e => e.Eventmanagerid == id));
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

        // GET: UrEventManagerProfile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UrEventManagerProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UrEventManagerProfile/Create
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

        // GET: UrEventManagerProfile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UrEventManagerProfile/Edit/5
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

        // GET: UrEventManagerProfile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UrEventManagerProfile/Delete/5
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
