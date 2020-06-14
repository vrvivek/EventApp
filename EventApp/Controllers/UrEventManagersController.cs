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

        [HttpPost]
        public ActionResult Index(int? Rating=0,string name="")
        {
            if (Session["uid"] != null)
            {
                if (Rating != 0 && name != "")
                {
                    var manager = db.Tbleventmanagers.SqlQuery(" select * from dbo.Tbleventmanager m where m.Eventmanagerid in (select m.Eventmanagerid from dbo.Tbleventmanager m join dbo.Tblreview r  on m.Eventmanagerid = r.Eventmanagerid where m.Name like '%" + name + "%' GROUP BY m.Eventmanagerid HAVING avg(r.Rating)=" + Rating + ") ");
                    return View(manager.ToList());
                }
                else if (Rating != 0) { 
                    var manager = db.Tbleventmanagers.SqlQuery(" select * from dbo.Tbleventmanager m where m.Eventmanagerid in (select m.Eventmanagerid from dbo.Tbleventmanager m join dbo.Tblreview r  on m.Eventmanagerid = r.Eventmanagerid GROUP BY m.Eventmanagerid HAVING avg(r.Rating)=" + Rating + ") ");
                    return View(manager.ToList());
                }
                else if(name != "")
                {
                    return View(db.Tbleventmanagers.Where(m=> m.Name.Contains(name) || m.Tbluser.Username.Contains(name)).ToList());
                }
                else
                    return View(db.Tbleventmanagers.ToList());
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

        // GET: UrEventManagers/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["uid"] != null)
            {
                var tenbid = db.Tblusertenderbids.Where(a => a.Eventmanagerid == id && a.Is_selected == 1);
                var tender = from b in tenbid join t in db.Tblusertenders on b.Usertenderid equals t.Usertenderid 
                             where t.Status == 2 select t;
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

        public ActionResult AddRating(int id,Tblreview rv)
        {
            if (Session["uid"] != null && Session["cid"] != null)
            {
                int cid = Convert.ToInt32(Session["cid"]);
                rv.Status = 0;
                rv.Eventmanagerid = id;
                rv.Clientid = cid;
                rv.Createddate = DateTime.Now;
                db.Tblreviews.Add(rv);
                db.SaveChanges();
                return RedirectToAction("Details/" + id.ToString());
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

        public ActionResult AddReportEventmanager(int id, Tblreporteventmnager re)
        {
            if (Session["uid"] != null && Session["cid"] != null)
            {
                int cid = Convert.ToInt32(Session["cid"]);
                re.Status = 0;
                re.Eventmanagerid = id;
                re.Clientid = cid;
                re.Createddate = DateTime.Now;
                db.Tblreporteventmnagers.Add(re);
                db.SaveChanges();
                return RedirectToAction("Details/" + id.ToString());
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

        public string PastworkLikeUnLike(int pid)
        {
            if(Session["cid"] != null)
            {
                int id = Convert.ToInt32(Session["cid"]);
                Tblpastworklike pl = db.Tblpastworklikes.SingleOrDefault(p => p.Pastworkid == pid && p.Clientid == id);
                if (pl == null)
                {
                    pl = new Tblpastworklike();
                    pl.Clientid = id;
                    pl.Pastworkid = pid;
                    pl.Createddate = DateTime.Now;
                    db.Tblpastworklikes.Add(pl);
                    db.SaveChanges();
                    return "<a href='#' onclick='return pastworklike("+pid+");'>"+db.Tblpastworklikes.Where(p=>p.Pastworkid==pid).Count()+"<i class='fa fa-heart'></i></a>";
                }
                else
                {
                    db.Tblpastworklikes.Remove(pl);
                    db.SaveChanges();
                    return "<a href='#' onclick='return pastworklike("+pid+");'>"+db.Tblpastworklikes.Where(p=>p.Pastworkid==pid).Count()+"<i class='far fa-heart'></i></a>";
                }
            }
            else
                return "";
        }
    }
}
