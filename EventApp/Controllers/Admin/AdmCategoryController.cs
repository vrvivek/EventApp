using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers.Admin
{
    public class AdmCategoryController : Controller
    {
        EventDB db = new EventDB();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["admname"] != null)
                base.OnActionExecuting(filterContext);
            else
                RedirectToAction("Index", "Login");
        }
        // GET: AdmCategory
        public ActionResult Index()
        {
            return View(db.Tblcategories.ToList());
        }

        // GET: AdmCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdmCategory/Create
        public ActionResult Create()
        {
            if (Session["admname"] != null)
                return View();
            else
                return RedirectToAction("Index","Login");
        }

        // POST: AdmCategory/Create
        [HttpPost]
        public ActionResult Create(Tblcategory c)
        {
            if (Session["admname"] != null)
            {
                if (db.Tblcategories.SingleOrDefault(a => a.Categoryname == c.Categoryname) != null)
                {
                    db.Tblcategories.Add(c);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.msg = "Category Already Exist.";
                    return View();
                }
            }
            else
                return RedirectToAction("Index", "Login");
        }

        // GET: AdmCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdmCategory/Edit/5
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

        // GET: AdmCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdmCategory/Delete/5
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
