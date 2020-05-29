using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers.Admin
{
    public class AdmManagertenderController : Controller
    {
        EventDB db = new EventDB();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["admname"] != null)
                base.OnActionExecuting(filterContext);
            else
                RedirectToAction("Index", "Login");
        }
        // GET: AdmManagertender
        public ActionResult Index()
        {
            return View(db.Tblmanagertenders.ToList());
        }

        // GET: AdmManagertender/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Tblmanagertenders.SingleOrDefault(i=>i.Managertenderid==id));
        }

        // GET: AdmManagertender/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdmManagertender/Create
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

        // GET: AdmManagertender/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdmManagertender/Edit/5
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

        // GET: AdmManagertender/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdmManagertender/Delete/5
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
