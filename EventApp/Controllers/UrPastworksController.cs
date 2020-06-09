using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers
{
    public class UrPastworksController : Controller
    {
        EventDB db = new EventDB();
        // GET: UrPastworks
        public ActionResult Index()
        {
            if (Session["uid"] != null)
            {
                int id =Convert.ToInt32( Session["mid"]);
                return View(db.Tblpastworks.Where(a=>a.Eventmanagerid == id).ToList());
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

        // GET: UrPastworks/Details/5
        public ActionResult Details(int id)
        {
            if (Session["uid"] != null)
                return View(db.Tblpastworks.SingleOrDefault(i => i.Pastworkid == id));
            else
                return RedirectToAction("Index", "UrLogin");
        }

        // GET: UrPastworks/Create
        public ActionResult Create()
        {
            if (Session["uid"] != null)
            {
                ViewBag.Subcategoryid = new SelectList(db.Tblsubcategories.ToList(), "Subcategoryid", "Subcategoryname");
                return View();
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

        // POST: UrPastworks/Create
        [HttpPost]
        public ActionResult Create(Tblpastwork pw, HttpPostedFileBase[] ImageURL, HttpPostedFileBase[] VideoURL)
        {
            ViewBag.Subcategoryid = new SelectList(db.Tblsubcategories.ToList(), "Subcategoryid", "Subcategoryname");
            if (pw != null && pw.Description != null && ImageURL.Count() != 0)
            {
                pw.Createddate = DateTime.Now;
                pw.Status = 0;
                pw.Eventmanagerid = Convert.ToInt32(Session["mid"]);
                db.Tblpastworks.Add(pw);
                db.SaveChanges();
                foreach (HttpPostedFileBase Image in ImageURL)
                {
                    var filename = System.IO.Path.GetFileName(Image.FileName);
                    Random random = new Random();
                    filename = random.Next(99, 99999) + "_Pastworkimage_" + filename;
                    var path = System.IO.Path.Combine(Server.MapPath("~/Content/Shared/Pastwork/Pastwork_Image"), filename);
                    Image.SaveAs(path);
                    Tblpastworkimage pwimg = new Tblpastworkimage();
                    pwimg.ImageURL = filename;
                    pwimg.Pastworkid = pw.Pastworkid;
                    db.Tblpastworkimages.Add(pwimg);
                    db.SaveChanges();
                }
                foreach(HttpPostedFileBase Video in VideoURL)
                {
                    var filename = System.IO.Path.GetFileName(Video.FileName);
                    Random random = new Random();
                    filename = random.Next(99, 99999) + "_Pastworkvideo_" + filename;
                    var path = System.IO.Path.Combine(Server.MapPath("~/Content/Shared/Pastwork/Pastwork_Video"), filename);
                    Video.SaveAs(path);
                    Tblpastworkvideo pwvideo = new Tblpastworkvideo();
                    pwvideo.VideoURL = filename;
                    pwvideo.Pastworkid = pw.Pastworkid;
                    db.Tblpastworkvideos.Add(pwvideo);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "UrPastworks");
            }
            else
            {
                ViewBag.msg = "Please Fill All The Fields";
                return View(pw);
            }
        }

        // GET: UrPastworks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UrPastworks/Edit/5
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

        // GET: UrPastworks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UrPastworks/Delete/5
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
