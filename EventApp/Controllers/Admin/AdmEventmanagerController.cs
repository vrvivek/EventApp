using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers.Admin
{
    public class AdmEventmanagerController : Controller
    {
        EventDB db = new EventDB();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["admname"] != null)
                base.OnActionExecuting(filterContext);
            else
                RedirectToAction("Index","Login");
        }
        // GET: AdmEventmanager
        public ActionResult Index()
        {
            if (Session["admname"] != null)
                return View(db.Tbleventmanagers.ToList());
            else
                return RedirectToAction("Index", "Login");
        }

        public string ChangeStatus(int? mid)
        {
            Tbleventmanager m = db.Tbleventmanagers.SingleOrDefault(a => a.Eventmanagerid == mid);
            if (m != null)
            {
                string str = "";
                if (m.Tbluser.Status == 0)
                {
                    str = "<a href='#' class='status' data-id='" + mid + "'><i class='ion ion-locked' ></i></a>";
                    m.Tbluser.Status = 1;
                }
                else
                {
                    str = "<a href='#' class='status' data-id='" + mid + "'><i class='fa fa-lock-open' ></i></a>";
                    m.Tbluser.Status = 0;
                }
                db.SaveChanges();
                return str;
            }
            else
                return "false";
        }

        // GET: AdmEventmanager/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Tbleventmanagers.SingleOrDefault(i=>i.Eventmanagerid ==id));
        }

        // GET: AdmEventmanager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdmEventmanager/Create
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

    }
}
