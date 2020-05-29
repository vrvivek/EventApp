using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers.Admin
{
    public class AdmDashboardController : Controller
    {
        // GET: AdmDashboard
        public ActionResult Index()
        {
            if (Session["admname"] != null)
                return View();
            else
                return RedirectToAction("Index", "Login");
        }

        // GET: AdmDashboard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdmDashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdmDashboard/Create
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

        // GET: AdmDashboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdmDashboard/Edit/5
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

        // GET: AdmDashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdmDashboard/Delete/5
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
