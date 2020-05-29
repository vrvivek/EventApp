using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers.Admin
{
    public class AdmUsertenderController : Controller
    {
        EventDB db = new EventDB();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["admname"] != null)
                base.OnActionExecuting(filterContext);
            else
                RedirectToAction("Index","Login");
        }
        // GET: AdmUsertender
        public ActionResult Index()
        {
            return View(db.Tblusertenders.ToList());
        }

        // GET: AdmUsertender/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Tblusertenders.SingleOrDefault(i => i.Usertenderid == id));
        }

        // GET: AdmUsertender/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdmUsertender/Create
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

        // GET: AdmUsertender/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdmUsertender/Edit/5
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

        // GET: AdmUsertender/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdmUsertender/Delete/5
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
