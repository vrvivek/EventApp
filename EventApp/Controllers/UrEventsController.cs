using EventApp.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers
{
    public class UrEventsController : Controller
    {
        EventDB db = new EventDB();
        // GET: UrEvents
        public ActionResult Index()
        {
            if (Session["uid"] != null )
                return View(db.Tblusertenders.ToList());
            else
                return RedirectToAction("Index", "UrLogin");
        }

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

        // GET: UrEvents/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UrEvents/Delete/5
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
