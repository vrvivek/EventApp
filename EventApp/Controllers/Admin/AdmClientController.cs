﻿using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApp.Controllers.Admin
{
    public class AdmClientController : Controller
    {
        EventDB db=new EventDB();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["admname"] != null)
                base.OnActionExecuting(filterContext);
            else
                RedirectToAction("Index", "Login");
        }
        // GET: AdmClient
        public ActionResult Index()
        {
            return View(db.Tblclients.ToList());
        }

        // GET: AdmClient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdmClient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdmClient/Create
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

        // GET: AdmClient/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdmClient/Edit/5
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

        // GET: AdmClient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdmClient/Delete/5
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
