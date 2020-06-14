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
            if (Session["admname"] != null)
                return View(db.Tblmanagertenders.ToList());
            else
                return RedirectToAction("Index", "Login");
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

        public string ChangeStatus(int? mtid)
        {
            Tblmanagertender mt = db.Tblmanagertenders.SingleOrDefault(a => a.Managertenderid == mtid);
            if (mt != null)
            {
                string str = "";
                if (mt.Status == 0)
                {
                    str = "<button class='btn btn-danger status' data-id='" + mtid + "'>Work in progress</button>";
                    mt.Status = 1;
                }
                else if (mt.Status == 1)
                {
                    str = "<button class='btn btn-danger status' data-id='" + mtid + "'>Cancel by admin</button>";
                    mt.Status = 2;
                }
                else if (mt.Status == 2)
                {
                    str = "<button class='btn btn-danger status' data-id='" + mtid + "'>Cancel by client</button>";
                    mt.Status = 3;
                }
                else if (mt.Status == 3)
                {
                    str = "<button class='btn btn-danger status' data-id='" + mtid + "'>Finished</button>";
                    mt.Status = 4;
                }
                else
                {
                    str = "<button class='btn btn-danger status' data-id='" + mtid + "'>Running</button>";
                    mt.Status = 0;
                }
                db.SaveChanges();
                return str;
            }
            else
                return "false";
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
