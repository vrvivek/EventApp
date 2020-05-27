using EventApp.Models;
using System;
using System.Linq;
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
            if (Session["uid"] != null && Session["cid"] != null)
            {
                ViewBag.Cityid = new SelectList(db.Tblcities.ToList(), "Cityid", "Cityname");
                return View();
            }
            else
                return RedirectToAction("Index","UrLogin");
        }

        // POST: UrEvents/Create
        [HttpPost]
        public ActionResult Create(Tblusertender ut)
        {
            ViewBag.Cityid = new SelectList(db.Tblcities, "Cityid", "Cityname");
            ut.Startingdate = DateTime.Now;
            ViewBag.d = ut.Startingdate;
            ViewBag.date = ut.Endingdate;
            return View();
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
