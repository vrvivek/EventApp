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
            if (Session["admid"] != null)
                return View(db.Tblusertenders.ToList());
            else
                return RedirectToAction("Index", "Login");
        }

        // GET: AdmUsertender/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Tblusertenders.SingleOrDefault(i => i.Usertenderid == id));
        }

        public string ChangeStatus(int? utid)
        {
            Tblusertender ut = db.Tblusertenders.SingleOrDefault(a => a.Usertenderid == utid);
            if (ut != null)
            {
                string str = "";
                if (ut.Status == 0)
                {
                    str = "<button class='btn btn-danger status' data-id='" + utid +"'>Work in progress</button>";
                    ut.Status = 1;
                }
                else if(ut.Status == 1)
                {
                    str = "<button class='btn btn-danger status' data-id='" + utid + "'>Cancel by admin</button>";
                    ut.Status = 2;
                }
                else if (ut.Status == 2)
                {
                    str = "<button class='btn btn-danger status' data-id='" + utid + "'>Cancel by client</button>";
                    ut.Status = 3;
                }
                else if (ut.Status == 3)
                {
                    str = "<button class='btn btn-danger status' data-id='" + utid + "'>Finished</button>";
                    ut.Status = 4;
                }
                else
                {
                    str = "<button class='btn btn-danger status' data-id='" + utid + "'>Running</button>";
                    ut.Status = 0;
                }
                db.SaveChanges();
                return str;
            }
            else
                return "false";
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
