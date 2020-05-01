using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers
{
    public class UrLoginController : Controller
    {
        EventDB db = new EventDB();
        // GET: UrLogin
        public ActionResult Index(string username="",string password="")
        {
            //if(username != "" && password != "")
            return View();
        }

        //GET: UrLogin/Register
        public ActionResult Register()
        {
            Session["city"] = db.Tblcities.ToList();
            ViewBag.state = db.Tblstates.ToList();
            return View();
        }

        public string CityBystate(int sid)
        {
            string city = "<option value='-1'>Select City</option>";
            List<Tblcity> clist =(List<Tblcity>)Session["city"];
            foreach (Tblcity i in clist.Where(a=>a.Stateid==sid))
            {
                city += "<option value='"+i.Cityid.ToString()+"'>"+i.Cityname+"</option>";
            }
            return city;
        }

        // GET: UrLogin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UrLogin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UrLogin/Create
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

        // GET: UrLogin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UrLogin/Edit/5
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

        // GET: UrLogin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UrLogin/Delete/5
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
