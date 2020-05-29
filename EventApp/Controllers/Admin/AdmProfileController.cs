using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers.Admin
{
    public class AdmProfileController : Controller
    {
        EventDB db = new EventDB();
        // GET: AdmProfile
        public ActionResult Index()
        {
            if (Session["admid"] != null)
            {
                int id = Convert.ToInt32(Session["admid"]);
                return View(db.Tbladmins.SingleOrDefault(a => a.Adminid ==id));
            }
            else
                return RedirectToAction("Index", "Login");
        }

        // GET: AdmProfile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdmProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdmProfile/Create
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

        // GET: AdmProfile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdmProfile/Edit/5
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

        // GET: AdmProfile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdmProfile/Delete/5
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
