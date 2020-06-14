using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers
{
    public class UrClientProfileController : Controller
    {
        EventDB db = new EventDB();
        // GET: UrClientProfile
        public ActionResult Index(int? ms=0)
        {
            if (Session["uid"] != null)
            {
                int id = Convert.ToInt32(Session["cid"]);
                ViewBag.tab1 = "active show";
                ViewBag.tab2 = "";
                ViewBag.cls = "";
                if (ms == 1)
                {
                    ViewBag.cls1 = "btn btn-success";
                    ViewBag.msg = "Details Change Success";
                }
                if (ms == 2)
                {
                    ViewBag.tab1 = "";
                    ViewBag.tab2 = "active show";
                    ViewBag.cls2 = "btn btn-danger";
                    ViewBag.msg1 = "Old Password Not Match";
                }
                if (ms == 3)
                {
                    ViewBag.tab1 = "";
                    ViewBag.tab2 = "active show";
                    ViewBag.cls2 = "btn btn-success";
                    ViewBag.msg1 = "Password Change Success";
                }
                if (ms == 4)
                {
                    ViewBag.tab1 = "";
                    ViewBag.tab2 = "active show";
                    ViewBag.cls2 = "btn btn-danger";
                    ViewBag.msg1 = "Password & Conform Password Not Match";
                }
                return View(db.Tblclients.SingleOrDefault(c => c.Clientid == id));
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

        public ActionResult MyEvents()
        {
            if (Session["uid"] != null && Session["cid"]!=null)
            {
                int id = Convert.ToInt32(Session["cid"]);
                return View(db.Tblusertenders.Where(a=>a.Clientid==id).ToList()) ;
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

        // GET: UrClientProfile/MyEventsDetails/5
        public ActionResult MyEventsDetails(int? id,int? st=0)
        {
            if (Session["uid"] != null && Session["cid"] != null)
            {
                if (st == 1)
                    ViewBag.stmsg = "success";
                return View(db.Tblusertenders.SingleOrDefault(a => a.Usertenderid == id));
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

        public ActionResult SelectEventBid(int id, int bid)
        {
            if (Session["cid"] != null)
            {
                Tblusertender t = db.Tblusertenders.SingleOrDefault(a=>a.Usertenderid==id);
                Tblusertenderbid utb = db.Tblusertenderbids.SingleOrDefault(b=>b.Usertenderbidid==bid && b.Usertenderid==id);
                t.Status = 2;
                utb.Is_selected = 1;
                db.SaveChanges();
                return RedirectToAction("MyEventsDetails/" + id,new { st=1});
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

        public string EditUserEvent(int tid,int Price,string Description,DateTime enddate)
        {
            if (Session["cid"] != null && tid != 0 && Price != 0 && Description != "" && enddate > DateTime.Now)
            {
                Tblusertender t = db.Tblusertenders.SingleOrDefault(a => a.Usertenderid == tid);
                t.Price = Price;
                t.Description = Description;
                t.Endingdate = enddate;
                db.SaveChanges();
                return "true";
            }
            else
                return "false";
        }

        // POST: UrClientProfile/EditDetails 
        [HttpPost]
        public ActionResult EditDetails(Tblclient c)
        {
            if (Session["cid"] != null)
            {
                int id = Convert.ToInt32(Session["cid"]);
                Tblclient c1 = db.Tblclients.SingleOrDefault(a => a.Clientid == id);
                c1.Address = c.Address;
                c1.Gender = c.Gender;
                c1.Zip = c.Zip;
                c1.Name = c.Name;
                c1.Dateofbirth = c.Dateofbirth;
                db.SaveChanges();
                return RedirectToAction("Index",new {ms = 1} );
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

        // POST: UrClientProfile/ChangePassword
        [HttpPost]
        public ActionResult ChangePassword(string oldpwd,string password,string conpwd)
        {
            if (Session["cid"] != null)
            {
                int id = Convert.ToInt32(Session["cid"]);
                Tblclient c1 = db.Tblclients.SingleOrDefault(a => a.Clientid == id);
                Tbluser ur = db.Tblusers.SingleOrDefault(a=>a.Userid==c1.Userid);
                if(ur.Password == oldpwd)
                {
                    if (password == conpwd)
                    {
                        ur.Password = password;
                        db.SaveChanges();
                        return RedirectToAction("Index", new { ms = 3 });
                    }
                    else
                        return RedirectToAction("Index",new { ms = 4 });
                }
                else
                    return RedirectToAction("Index", new { ms = 2 });
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

    }
}
