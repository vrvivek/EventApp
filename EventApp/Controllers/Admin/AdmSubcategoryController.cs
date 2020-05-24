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
    public class AdmSubcategoryController : Controller
    {
        private EventDB db = new EventDB();

        // GET: AdmSubcategory
        public ActionResult Index()
        {
            var tblsubcategories = db.Tblsubcategories.Include(t => t.Tblcategory);
            return View(tblsubcategories.ToList());
        }

        // GET: AdmSubcategory/Details/5
        public ActionResult Details(int? id)
        {
            Tblsubcategory tblsubcategory = db.Tblsubcategories.Find(id);
            if (tblsubcategory == null)
            {
                return HttpNotFound();
            }
            return View(tblsubcategory);
        }

        // GET: AdmSubcategory/Create
        public ActionResult Create()
        {
            ViewBag.Categoryid = new SelectList(db.Tblcategories, "Categoryid", "Categoryname");
            return View();
        }

        // POST: AdmSubcategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Subcategoryid,Subcategoryname,Categoryid")] Tblsubcategory tblsubcategory)
        {
            if (ModelState.IsValid)
            {
                db.Tblsubcategories.Add(tblsubcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categoryid = new SelectList(db.Tblcategories, "Categoryid", "Categoryname", tblsubcategory.Categoryid);
            return View(tblsubcategory);
        }

        // GET: AdmSubcategory/Edit/5
        public ActionResult Edit(int? id)
        {
            Tblsubcategory tblsubcategory = db.Tblsubcategories.Find(id);
            if (tblsubcategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categoryid = new SelectList(db.Tblcategories, "Categoryid", "Categoryname", tblsubcategory.Categoryid);
            return View(tblsubcategory);
        }

        // POST: AdmSubcategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Subcategoryid,Subcategoryname,Categoryid")] Tblsubcategory tblsubcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblsubcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categoryid = new SelectList(db.Tblcategories, "Categoryid", "Categoryname", tblsubcategory.Categoryid);
            return View(tblsubcategory);
        }

        // GET: AdmSubcategory/Delete/5
        public ActionResult Delete(int? id)
        {
            Tblsubcategory tblsubcategory = db.Tblsubcategories.Find(id);
            if (tblsubcategory == null)
            {
                return HttpNotFound();
            }
            return View(tblsubcategory);
        }

        // POST: AdmSubcategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tblsubcategory tblsubcategory = db.Tblsubcategories.Find(id);
            db.Tblsubcategories.Remove(tblsubcategory);
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
