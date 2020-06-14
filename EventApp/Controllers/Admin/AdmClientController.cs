using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers.Admin
{
    public class AdmClientController : Controller
    {
        EventDB db=new EventDB();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["admname"] != null)
                base.OnActionExecuting(filterContext);
            else
                RedirectToAction("Index", "Login");
        }
        // GET: AdmClient
        public ActionResult Index()
        {
            if (Session["admname"] != null)
                return View(db.Tblclients.ToList());
            else
                return RedirectToAction("Index", "Login");
        }

        public string ChangeStatus(int? cid)
        {
            Tblclient c = db.Tblclients.SingleOrDefault(a => a.Clientid == cid);
            if (c != null)
            {
                string str = "";
                if (c.Tbluser.Status == 0)
                {
                    str = "<a href='#' class='status' data-id='"+cid+"'><i class='ion ion-locked' ></i></a>";
                    c.Tbluser.Status = 1;
                }
                else
                {
                    str = "<a href='#' class='status' data-id='" + cid + "'><i class='fa fa-lock-open' ></i></a>";
                    c.Tbluser.Status = 0;
                }
                db.SaveChanges();
                return str;
            }
            else
                return "false";
        }

        // GET: AdmClient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdmClient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdmClient/Create
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
