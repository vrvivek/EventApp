using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers
{
    public class UrEventManagersController : Controller
    {
        EventDB db = new EventDB();
        // GET: UrEventManagers
        public ActionResult Index()
        {
            if (Session["uid"] != null)
                return View(db.Tbleventmanagers.ToList()) ;
            else
                return RedirectToAction("Index", "UrLogin");
        }

        // GET: UrEventManagers/Details/5
        public ActionResult Details(int id)
        {
            if (Session["uid"] != null)
            {
                var tenbid = db.Tblusertenderbids.Where(a => a.Eventmanagerid == id && a.Is_selected == 1);
                List<Tblusertender> tender = (List<Tblusertender>)from b in tenbid join t in db.Tblusertenders on b.Usertenderid equals t.Usertenderid where t.Status == 2 select t;
                ViewBag.ctender = tender.ToList();
                return View(db.Tbleventmanagers.SingleOrDefault(e => e.Eventmanagerid == id));
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

        // GET: UrEventManagers/PastworkDetails/5
        public ActionResult PastworkDetails(int id)
        {
            if(Session["uid"]!=null)
               return View(db.Tblpastworks.SingleOrDefault(p => p.Pastworkid == id));
            else
                return RedirectToAction("Index", "UrLogin");
        }

        // GET: UrEventManagers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UrEventManagers/Create
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

        // GET: UrEventManagers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UrEventManagers/Edit/5
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

        // GET: UrEventManagers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UrEventManagers/Delete/5
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
