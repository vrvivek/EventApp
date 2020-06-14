using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers
{
    public class UrChatsController : Controller
    {
        EventDB db = new EventDB();
        // GET: UrChats
        public ActionResult Index()
        {
            if (Session["uid"] != null)
            {
                int id = Convert.ToInt32( Session["uid"]);
                var chatuser = db.Tblusers.SqlQuery("select * from dbo.Tbluser u where u.Userid in (select c.Receiverid from dbo.Tblchat c where c.Senderid=" + id + ")");
                return View(chatuser.ToList());
            }
            else
                return RedirectToAction("Index","UrLogin");
        }

        public ActionResult getChat(int id)
        {
            int uid = Convert.ToInt32(Session["uid"]);
            ViewBag.user = db.Tblusers.SingleOrDefault(a => a.Userid == id);
            return View(db.Tblchats.Where(a => a.Senderid == uid && a.Receiverid == id || a.Senderid == id && a.Receiverid == uid).ToList());
        }

        public ActionResult refreshChat(int id)
        {
            int uid = Convert.ToInt32(Session["uid"]);
            return View(db.Tblchats.Where(a => a.Senderid == uid && a.Receiverid == id || a.Senderid == id && a.Receiverid == uid).ToList());
        }

        public ActionResult sendMsg(string msg, int rid)
        {
            int uid = Convert.ToInt32(Session["uid"]);
            db.Tblchats.Add(new Tblchat { Senderid = Convert.ToInt32(Session["uid"]), Receiverid = rid, Message = msg , Status=0 , Createddate=DateTime.Now});
            db.SaveChanges();
            return View(db.Tblchats.Where(a => a.Senderid == uid && a.Receiverid == rid || a.Senderid == rid && a.Receiverid == uid).ToList());
        }
    }
}
