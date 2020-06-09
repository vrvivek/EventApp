using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers
{
    public class UrEventManagerProfileController : Controller
    {
        EventDB db = new EventDB();
        // GET: UrEventManagerProfile
        public ActionResult Index(int? ms=0)
        {
            if (Session["uid"] != null)
            {
                int id = Convert.ToInt32(Session["mid"]);
                ViewBag.tab1 = "active show";
                ViewBag.tab2 = "";
                ViewBag.cls = "";
                if(ms == 1)
                {
                    ViewBag.cls1 = "btn btn-success";
                    ViewBag.msg = "Details Change Success";
                }
                if(ms == 2)
                {
                    ViewBag.tab1 = "";
                    ViewBag.tab2 = "active show";
                    ViewBag.cls2 = "btn btn-danger";
                    ViewBag.msg1 = "Old Password Not Match";
                }
                if(ms == 3)
                {
                    ViewBag.tab1 = "";
                    ViewBag.tab2 = "active show";
                    ViewBag.cls2 = "btn btn-success";
                    ViewBag.msg1 = "Password Change Success";
                }
                if(ms == 4)
                {
                    ViewBag.tab1 = "";
                    ViewBag.tab2 = "active show";
                    ViewBag.cls2 = "btn btn-danger";
                    ViewBag.msg1 = "Password & Conform Password Not Match";
                }
                return View(db.Tbleventmanagers.SingleOrDefault(e => e.Eventmanagerid == id));
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

        public string MyEvents()
        {
            return "csdfsf";
        }

        // GET: UrClientProfile/MyEventsDetails/5
        public ActionResult MyEventsDetails(int id)
        {
            return View();
        }

        // POST: UrEventManagerProfile/EditDetails
        [HttpPost]
        public ActionResult EditDetails(Tbleventmanager e, HttpPostedFileBase Coverpic)
        {
            if(Session["mid"]!=null)
            {
                
                int id = Convert.ToInt32(Session["mid"]);
                Tbleventmanager e1 = db.Tbleventmanagers.SingleOrDefault(m=>m.Eventmanagerid==id);
                e1.Companyname = e.Companyname;
                e1.Website = e.Website;
                e1.Name = e.Name;
                e1.About = e.About;
                if (Coverpic != null)
                {
                    var filename = System.IO.Path.GetFileName(Coverpic.FileName);
                    Random random = new Random();
                    filename = random.Next(0, 99999)+"_Cover_" + filename;
                    var path = System.IO.Path.Combine(Server.MapPath("~/Content/Shared/Eventer_Image"), filename);
                    Coverpic.SaveAs(path);
                    e1.Coverpic = filename;
                }
                db.SaveChanges();
                return RedirectToAction("Index",new { ms = 1});
            }
            else
                return RedirectToAction("Index","UrLogin");
        }

        // POST: UrEventManagerProfile/ChangePassword
        [HttpPost]
        public ActionResult ChangePassword(string oldpwd, string password, string conpwd)
        {
            if (Session["mid"] != null)
            {
                int id = Convert.ToInt32(Session["mid"]);
                Tbleventmanager e1 = db.Tbleventmanagers.SingleOrDefault(m => m.Eventmanagerid == id);
                Tbluser ur = db.Tblusers.SingleOrDefault(u=>u.Userid==e1.Userid);
                if (ur.Password == oldpwd)
                {
                    if (password == conpwd)
                    {
                        ur.Password = password;
                        db.SaveChanges();
                        return RedirectToAction("Index", new { ms = 3 });
                    }
                    else
                        return RedirectToAction("Index", new { ms = 4 });
                }
                else
                    return RedirectToAction("Index", new { ms = 2 });
            }
            else
                return RedirectToAction("Index","UrLogin");
        }

            // GET: UrEventManagerProfile/Delete/5
            public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UrEventManagerProfile/Delete/5
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
