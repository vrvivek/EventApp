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
    public class AdmStateController : Controller
    {
        private EventDB db = new EventDB();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["admname"] != null)
                base.OnActionExecuting(filterContext);
            else
                RedirectToAction("Index", "Login");
        }

        // GET: AdmState
        public ActionResult Index()
        {
            if (Session["admid"] != null)
                return View(db.Tblstates.ToList());
            else
                return RedirectToAction("Index", "Login");
        }

        // GET: AdmState/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tblstate tblstate = db.Tblstates.Find(id);
            if (tblstate == null)
            {
                return HttpNotFound();
            }
            return View(tblstate);
        }

        // GET: AdmState/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdmState/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Stateid,Statename")] Tblstate tblstate)
        {
            if (ModelState.IsValid)
            {
                db.Tblstates.Add(tblstate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblstate);
        }

        // GET: AdmState/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tblstate tblstate = db.Tblstates.Find(id);
            if (tblstate == null)
            {
                return HttpNotFound();
            }
            return View(tblstate);
        }

        // POST: AdmState/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Stateid,Statename")] Tblstate tblstate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblstate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblstate);
        }

        // GET: AdmState/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tblstate tblstate = db.Tblstates.Find(id);
            if (tblstate == null)
            {
                return HttpNotFound();
            }
            return View(tblstate);
        }

        // POST: AdmState/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tblstate tblstate = db.Tblstates.Find(id);
            db.Tblstates.Remove(tblstate);
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
