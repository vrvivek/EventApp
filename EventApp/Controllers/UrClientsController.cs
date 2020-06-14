using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers
{
    public class UrClientsController : Controller
    {
        EventDB db = new EventDB();
        // GET: UrClients
        public ActionResult Index()
        {
            return View();
        }

        // GET: UrClients/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["uid"] != null)
            {
                return View(db.Tblclients.SingleOrDefault(c => c.Clientid == id));
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }
        public ActionResult AddReportUser(int id, Tblreportuser ru)
        {
            if (Session["uid"] != null && Session["mid"] != null)
            {
                int mid = Convert.ToInt32(Session["mid"]);
                ru.Status = 0;
                ru.Clientid = id;
                ru.Eventmanagerid =mid;
                ru.Createddate = DateTime.Now;
                db.Tblreportusers.Add(ru);
                db.SaveChanges();
                return RedirectToAction("Details/" + id.ToString());
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

        // GET: UrClients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UrClients/Create
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
