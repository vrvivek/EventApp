using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers.Admin
{
    public class AdmReportUserController : Controller
    {
        EventDB db = new EventDB();
        // GET: AdmReportUser
        public ActionResult Index()
        {
            if (Session["admid"] != null)
                return View(db.Tblreportusers.ToList());
            else
                return RedirectToAction("Index", "Login");
        }

        public string ChangeStatus(int? ruid)
        {
            Tblreportuser ru = db.Tblreportusers.SingleOrDefault(a => a.Reportuserid == ruid);
            if (ru != null)
            {
                string str = "";
                if (ru.Status == 0)
                {
                    str = "<a href='#' class='status' data-id='" + ruid + "'><i class='ion ion-locked' ></i></a>";
                    ru.Status = 1;
                }
                else
                {
                    str = "<a href='#' class='status' data-id='" + ruid + "'><i class='fa fa-lock-open' ></i></a>";
                    ru.Status = 0;
                }
                db.SaveChanges();
                return str;
            }
            else
                return "false";
        }

        // GET: AdmReportUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdmReportUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdmReportUser/Create
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

        // GET: AdmReportUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdmReportUser/Edit/5
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

        // GET: AdmReportUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdmReportUser/Delete/5
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
