using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventApp.Models;

namespace EventApp.Controllers.Admin
{
    public class AdmCityController : Controller
    {
        private EventDB db = new EventDB();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["admname"] != null)
                base.OnActionExecuting(filterContext);
            else
                RedirectToAction("Index", "Login");
        }

        // GET: AdmCity
        public ActionResult Index()
        {
            if (Session["admname"] != null)
            {
                var tblcities = db.Tblcities.Include(t => t.Tblstate);
                return View(tblcities.ToList());
            }
            else
                return RedirectToAction("Index", "Login");
        }

        // GET: AdmCity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tblcity tblcity = db.Tblcities.Find(id);
            if (tblcity == null)
            {
                return HttpNotFound();
            }
            return View(tblcity);
        }

        // GET: AdmCity/Create
        public ActionResult Create()
        {
            ViewBag.Stateid = new SelectList(db.Tblstates, "Stateid", "Statename");
            return View();
        }

        // POST: AdmCity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cityid,Cityname,Stateid")] Tblcity tblcity)
        {
            if (ModelState.IsValid)
            {
                db.Tblcities.Add(tblcity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Stateid = new SelectList(db.Tblstates, "Stateid", "Statename", tblcity.Stateid);
            return View(tblcity);
        }

        // GET: AdmCity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tblcity tblcity = db.Tblcities.Find(id);
            if (tblcity == null)
            {
                return HttpNotFound();
            }
            ViewBag.Stateid = new SelectList(db.Tblstates, "Stateid", "Statename", tblcity.Stateid);
            return View(tblcity);
        }

        // POST: AdmCity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cityid,Cityname,Stateid")] Tblcity tblcity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblcity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Stateid = new SelectList(db.Tblstates, "Stateid", "Statename", tblcity.Stateid);
            return View(tblcity);
        }

        // GET: AdmCity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tblcity tblcity = db.Tblcities.Find(id);
            if (tblcity == null)
            {
                return HttpNotFound();
            }
            return View(tblcity);
        }

        // POST: AdmCity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tblcity tblcity = db.Tblcities.Find(id);
            db.Tblcities.Remove(tblcity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
