using EventApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (username != "" && password != "")
                ViewBag.msg = "";
            else
                ViewBag.msg = "";
                return View();
        }

        //GET: UrLogin/Register
        public ActionResult Register()
        {
            Session["city"] = db.Tblcities.ToList();
            ViewBag.state = db.Tblstates.ToList();
            return View();
        }

        // POST: UrLogin/Register
        [HttpPost]
        public ActionResult Register(Tbluser ur,HttpPostedFileBase Profilepic)
        {
            Session["city"] = db.Tblcities.ToList();
            ViewBag.state = db.Tblstates.ToList();
            if (ur!= null)
            {
                var filename = Path.GetFileName(Profilepic.FileName);
                ur.Registrationdate = DateTime.Now;
                Random random = new Random();
                filename = random.Next(0,99999)+filename;
                if(ur.Usertype==1)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/Shared/Client_Image"),filename);
                    Profilepic.SaveAs(path);
                    ur.Profilepic = filename;
                    db.Tblusers.Add(ur);
                    db.SaveChanges();
                    Tblclient c = new Tblclient();
                    c.Userid = ur.Userid;
                    c.Name = ur.Username;
                    db.Tblclients.Add(c);
                    db.SaveChanges();
                }
                if(ur.Usertype==2)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/Shared/Eventer_Image"), filename);
                    Profilepic.SaveAs(path);
                    ur.Profilepic = filename;
                    db.Tblusers.Add(ur);
                    db.SaveChanges();
                    Tbleventmanager em = new Tbleventmanager();
                    em.Userid = ur.Userid;
                    db.Tbleventmanagers.Add(em);
                    db.SaveChanges();
                }
            }
            else
            {
                ViewBag.msg = "Please Fill All The Fields.";
            }
            return View();
        }

        public string CheckUsername(string name)
        {
            if (name.Contains(" "))
                return "Username name can not contains space";
            else
            {
                if (db.Tblusers.Where(a => a.Username == name).Count() > 0)
                {
                    return "Username is alreay taken.";
                }
                else
                    return "";
            }
        }
        public string CityBystate(int sid)
        {
            string city = "<option value=''>Select City</option>";
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
