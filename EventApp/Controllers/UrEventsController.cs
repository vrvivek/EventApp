using EventApp.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace EventApp.Controllers
{
    public class UrEventsController : Controller
    {
        EventDB db = new EventDB();
        // GET: UrEvents
        public ActionResult Index()
        {
            if (Session["uid"] != null)
            {
                ViewBag.category = db.Tblcategories.ToList();
                ViewBag.state = db.Tblstates.ToList();
                return View(db.Tblusertenders.ToList());
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

        [HttpPost]
        public ActionResult Index(int? sid=0,int? cid=0)
        {
            if (Session["uid"] != null)
            {
                ViewBag.category = db.Tblcategories.ToList();
                ViewBag.state = db.Tblstates.ToList();
                if (sid!=0 && cid!= 0)
                {
                    return View(db.Tblusertenders.Where(a=>a.Subcategoryid==sid && a.Cityid==cid &&  a.Status==0).ToList());
                }
                else if (sid!=0)
                {
                    return View(db.Tblusertenders.Where(a => a.Subcategoryid == sid && a.Status == 0).ToList());
                }
                else if(cid!=0)
                {
                    return View(db.Tblusertenders.Where(a => a.Cityid == cid && a.Status == 0).ToList());
                }
                else
                    return View(db.Tblusertenders.ToList());
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

        public string SubCategoryByCategory(int id)
        {
            string subcat = "<option value='0'> Select </option> ";
            foreach (Tblsubcategory sub in db.Tblsubcategories.Where(a => a.Categoryid == id))
            {
                subcat = subcat + "<option value='"+sub.Subcategoryid+"'>"+sub.Subcategoryname+"</option+>";
            }
            return subcat;
        }

        public string CityByState(int id)
        {
            string city = "<option value='0'> Select </option> ";
            foreach (Tblcity c in db.Tblcities.Where(a => a.Stateid == id))
            {
                city = city + "<option value='" + c.Cityid + "'>" + c.Cityname + "</option+>";
            }
            return city;
        }

        //[HttpPost]
        //public ActionResult SearchEvents(int? sid=0,int? cid=0)
        //{
        //    if (sid != 0)
        //    {
        //        var SearchData = JsonConvert.SerializeObject(db.Tblusertenders.Where(a => a.Subcategoryid == sid).Select(y=> new { 
        //              y.Description,
        //              y.Clientid,
        //              y.Endingdate,
        //              y.Price,
        //              y.Status,
        //              y.Tblsubcategory.Subcategoryname,
        //              y.Tblsubcategory.Tblcategory.Categoryname,
        //              y.Tblcity.Cityname,
        //              y.Tblclient.Name,
        //              y.Tblcity.Tblstate.Statename,
        //              y.Usertenderid
        //        }).ToList());
        //        return Json(new { Data = SearchData });
        //    }
        //    else if (cid != 0)
        //    {
        //        return Json(db.Tblusertenders.Where(a => a.Cityid == cid), JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //        return Json(db.Tblusertenders.ToList(), JsonRequestBehavior.AllowGet);
        //}

        // GET: UrEvents/Create
        public ActionResult Create()
        {
            if (Session["uid"] != null && Session["cid"] != null)
            {
                ViewBag.Cityid = new SelectList(db.Tblcities.ToList(), "Cityid", "Cityname");
                ViewBag.Subcategoryid = new SelectList(db.Tblsubcategories.ToList(), "Subcategoryid", "Subcategoryname");
                return View();
            }
            else
                return RedirectToAction("Index","UrLogin");
        }

        // POST: UrEvents/Create
        [HttpPost]
        public ActionResult Create(Tblusertender ut)
        {
            ViewBag.Cityid = new SelectList(db.Tblcities, "Cityid", "Cityname");
            ViewBag.Subcategoryid = new SelectList(db.Tblsubcategories.ToList(), "Subcategoryid", "Subcategoryname");
            if (ut != null && ut.Description!=null && ut.Price!=0) 
            {
                ut.Startingdate = DateTime.Now;
                ut.Status = 0;
                ut.Clientid = Convert.ToInt32(Session["cid"]);
                db.Tblusertenders.Add(ut);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else 
            {
                ViewBag.msg = "Please Fill All The Fields";
                return View(ut);
            }
        }

        // GET: UrEvents/ManagerEventCreate
        public ActionResult ManagerEventCreate()
        {
            if (Session["uid"] != null && Session["mid"] != null)
            {
                ViewBag.Cityid = new SelectList(db.Tblcities.ToList(), "Cityid", "Cityname");
                ViewBag.Subcategoryid = new SelectList(db.Tblsubcategories.ToList(), "Subcategoryid", "Subcategoryname");
                return View();
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

        // POST: UrEvents/ManagerEventCreate
        [HttpPost]
        public ActionResult ManagerEventCreate(Tblmanagertender mt)
        {
            ViewBag.Cityid = new SelectList(db.Tblcities, "Cityid", "Cityname");
            ViewBag.Subcategoryid = new SelectList(db.Tblsubcategories.ToList(), "Subcategoryid", "Subcategoryname");
            if (mt != null && mt.Description != null && mt.Price != 0)
            {
                mt.Startingdate = DateTime.Now;
                mt.Status = 0;
                mt.Eventmanagerid = Convert.ToInt32(Session["mid"]);
                db.Tblmanagertenders.Add(mt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.msg = "Please Fill All The Fields";
                return View(mt);
            }
        }

        // GET: UrEvents/EventsInfo/5
        public ActionResult EventsInfo(int id=0,int bidmsg=0)
        {
            if (Session["uid"] != null)
            {
                ViewBag.cls = "";
                if (bidmsg == 1)
                {
                    ViewBag.msg = "Please Fill All Fields.";
                    ViewBag.cls = "danger";
                }
                if (bidmsg == 2)
                {
                    ViewBag.msg = "Please Fill All Fields.";
                    ViewBag.cls = "success";
                }
                return View(db.Tblusertenders.SingleOrDefault(a => a.Usertenderid == id));
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

        public ActionResult AddUserEventBid(int id,Tblusertenderbid ubid, HttpPostedFileBase [] ImageURL)
        {
            if (id != 0 && ubid.Price != 0 && ImageURL.Count() != 0)
            {
                ubid.Createddate = DateTime.Now;
                ubid.Is_selected = 0;
                ubid.Eventmanagerid = Convert.ToInt32(Session["mid"]);
                ubid.Usertenderid = id;
                db.Tblusertenderbids.Add(ubid);
                db.SaveChanges();
                foreach (HttpPostedFileBase Image in ImageURL)
                {
                    var filename = System.IO.Path.GetFileName(Image.FileName);
                    Random random = new Random();
                    filename = random.Next(99, 99999) + "_Bid_" + filename;
                    var path = System.IO.Path.Combine(Server.MapPath("~/Content/Shared/ClientEventBid_Image"), filename);
                    Image.SaveAs(path);
                    Tblusertenderbidimage utbi = new Tblusertenderbidimage();
                    utbi.ImageURL = filename;
                    utbi.Usertenderbidid = ubid.Usertenderbidid;
                    db.Tblusertenderbidimages.Add(utbi);
                    db.SaveChanges();
                }
                return RedirectToAction("EventsInfo" ,new { id,bidmsg=2});
            }
            else
                return RedirectToAction("EventsInfo" ,new { id ,bidmsg=1});
        }

        public string EditUserEventBid(int bid,int Price,string Description)
        {
            Tblusertenderbid b = db.Tblusertenderbids.SingleOrDefault(a=>a.Usertenderbidid==bid);
            if (b != null && Session["mid"] != null && bid != 0 )
            {
                b.Price = Price;
                b.Description = Description;
                db.SaveChanges();
                return "true";
            }
            else
                return "false";
        }

        public ActionResult ManagerEvents()
        {
            if (Session["uid"] != null)
                return View(db.Tblmanagertenders.ToList());
            else
                return RedirectToAction("Index", "UrLogin");
        }

        public ActionResult ManagerEventsDetails(int id = 0, int bidmsg = 0)
        {
            if (Session["uid"] != null)
            {
                ViewBag.cls = "";
                if (bidmsg == 1)
                {
                    ViewBag.msg = "Please Fill All Fields.";
                    ViewBag.cls = "danger";
                }
                if (bidmsg == 2)
                {
                    ViewBag.msg = "Please Fill All Fields.";
                    ViewBag.cls = "success";
                }
                return View(db.Tblmanagertenders.SingleOrDefault(a => a.Managertenderid == id));
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

        public ActionResult AddManagerEventBid(int id, Tblmanagertenderbid mbid, HttpPostedFileBase[] ImageURL)
        {
            if (id != 0 && mbid.Price != 0 && ImageURL.Count() != 0)
            {
                mbid.Createddate = DateTime.Now;
                mbid.Is_selected = 0;
                mbid.Eventmanagerid = Convert.ToInt32(Session["mid"]);
                mbid.Managertenderid = id;
                db.Tblmanagertenderbids.Add(mbid);
                db.SaveChanges();
                foreach (HttpPostedFileBase Image in ImageURL)
                {
                    var filename = System.IO.Path.GetFileName(Image.FileName);
                    Random random = new Random();
                    filename = random.Next(99, 99999) + "_Bid_" + filename;
                    var path = System.IO.Path.Combine(Server.MapPath("~/Content/Shared/ManagerEventBid_Image"), filename);
                    Image.SaveAs(path);
                    Tblmanagertenderbidimage mtbi = new Tblmanagertenderbidimage();
                    mtbi.ImageURL = filename;
                    mtbi.Managertenderbidid = mbid.Managertenderbidid;
                    db.Tblmanagertenderbidimages.Add(mtbi);
                    db.SaveChanges();
                }
                return RedirectToAction("ManagerEventsDetails", new { id, bidmsg = 2 });
            }
            else
                return RedirectToAction("ManagerEventsDetails", new { id, bidmsg = 1 });
        }
        public string EditManagerEventBid(int bid, int Price, string Description)
        {
            Tblmanagertenderbid b = db.Tblmanagertenderbids.SingleOrDefault(a => a.Managertenderbidid == bid);
            if (b != null && Session["mid"] != null && bid != 0)
            {
                b.Price = Price;
                b.Description = Description;
                db.SaveChanges();
                return "true";
            }
            else
                return "false";
        }
    }
}
