using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers
{
    public class UrPastworksController : Controller
    {
        EventDB db = new EventDB();
        // GET: UrPastworks
        public ActionResult Index()
        {
           
                return View(db.Tblpastworks.ToList());
            
        }

        // GET: UrPastworks/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Tblpastworks.SingleOrDefault(i => i.Pastworkid == id));
        }

        // GET: UrPastworks/Create
        public ActionResult Create()
        {
            ViewBag.Subcategoryid = new SelectList(db.Tblsubcategories.ToList(), "Subcategoryid", "Subcategoryname");
            return View();
        }

        // POST: UrPastworks/Create
        [HttpPost]
        public ActionResult Create(Tblpastwork pw)
        {
            ViewBag.Subcategoryid = new SelectList(db.Tblsubcategories.ToList(), "Subcategoryid", "Subcategoryname");
            if (pw != null && pw.Description != null)
            {
                pw.Createddate = DateTime.Now;
                pw.Status = 0;
                pw.Eventmanagerid = Convert.ToInt32(Session["cid"]);
                db.Tblpastworks.Add(pw);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.msg = "Please Fill All The Fields";
                return View(pw);
            }
        }

        // GET: UrPastworks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UrPastworks/Edit/5
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

        // GET: UrPastworks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UrPastworks/Delete/5
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
