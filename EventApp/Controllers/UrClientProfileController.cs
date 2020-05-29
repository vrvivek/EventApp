﻿using EventApp.Models;
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
        public ActionResult Index()
        {
            if (Session["uid"] != null)
            {
                int id = Convert.ToInt32(Session["cid"]);
                return View(db.Tblclients.SingleOrDefault(c => c.Clientid == id));
            }
            else
                return RedirectToAction("Index", "UrLogin");
        }

        // GET: UrClientProfile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UrClientProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UrClientProfile/Create
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

        // GET: UrClientProfile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UrClientProfile/Edit/5
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

        // GET: UrClientProfile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UrClientProfile/Delete/5
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
