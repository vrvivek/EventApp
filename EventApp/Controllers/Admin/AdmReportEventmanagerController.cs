using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers.Admin
{
    public class AdmReportEventmanagerController : Controller
    {
        EventDB db = new EventDB();
        // GET: AdmReportEventmanager
        public ActionResult Index()
        {
            if (Session["admid"] != null)
                return View(db.Tblreporteventmnagers.ToList());
            else
                return RedirectToAction("Index", "Login");
        }

        public string ChangeStatus(int? reid)
        {
            Tblreporteventmnager re = db.Tblreporteventmnagers.SingleOrDefault(a => a.Reporteventmanagerid == reid);
            if (re != null)
            {
                string str = "";
                if (re.Status == 0)
                {
                    str = "<a href='#' class='status' data-id='" + reid + "'><i class='ion ion-locked' ></i></a>";
                    re.Status = 1;
                }
                else
                {
                    str = "<a href='#' class='status' data-id='" + reid + "'><i class='fa fa-lock-open' ></i></a>";
                    re.Status = 0;
                }
                db.SaveChanges();
                return str;
            }
            else
                return "false";
        }

        // GET: AdmReportEventmanager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdmReportEventmanager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdmReportEventmanager/Create
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

        // GET: AdmReportEventmanager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdmReportEventmanager/Edit/5
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

        // GET: AdmReportEventmanager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdmReportEventmanager/Delete/5
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
