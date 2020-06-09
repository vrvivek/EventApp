using EventApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace EventApp.Controllers
{
    public class UrLoginController : Controller
    {
        EventDB db = new EventDB();
        
        
        // GET: UrLogin
        public ActionResult Index(int? Usertype,string username="",string password="")
        {
            
            if (Session["uid"] != null)
            {
                return RedirectToAction("Index", "UrEvents");
            }
            if (Usertype != null && username != "" && password != "")
            {
                Tbluser ur = db.Tblusers.SingleOrDefault(a => a.Username == username && a.Password == password && a.Usertype == Usertype);
                if (ur != null)
                {
                    //sendemail(ur.Email,ur.Username);
                    //sendmessage();
                    Session["uid"] = ur.Userid;
                    Session["uname"] = ur.Username;
                    Session["utype"] = ur.Usertype;
                    Session["upic"] = ur.Profilepic;
                    if (ur.Usertype == 1)
                    {
                        Tblclient c = db.Tblclients.SingleOrDefault(a=>a.Userid==ur.Userid);
                        Session["cid"] = c.Clientid;
                        return RedirectToAction("Index","UrEvents");
                    }
                    else
                    {
                        Tbleventmanager m = db.Tbleventmanagers.SingleOrDefault(a=>a.Userid==ur.Userid);
                        Session["mid"] = m.Eventmanagerid;
                        return RedirectToAction("Index", "UrEvents");
                    }
                }
                else
                {
                    ViewBag.msgtype = "text";
                    ViewBag.msg = "Invalid Username and Password";
                }
            }
            else
            {
                ViewBag.msgtype = "hidden";
                ViewBag.msg = "";
            }
            return View();
        }

        private void sendmessage()
        {
            const string accountSid = "AC878f8a350d44c83027a6ae6b4eaad8e1";
            const string authToken = "068c2172bdfee994df9743fdcebfb5e2";
            TwilioClient.Init(accountSid, authToken);
            var message = MessageResource.Create(
                body: "Your Account Log in Now ."+DateTime.Now.ToString(),
                from: new Twilio.Types.PhoneNumber("+13024552847"),
                to: new Twilio.Types.PhoneNumber("+918200652502")
            );
            
            Console.WriteLine(message.Status+" "+message.Sid);
        }

        private void sendemail(string remail,string rname)
        {
            if (ModelState.IsValid)
            {
                var senderEmail = new MailAddress("interiordecorvkh@gmail.com", "Eventively",System.Text.Encoding.UTF8);
                var receiverEmail = new MailAddress(remail, rname);
                var password = "interior123";
                var sub = "Sign In To Eventively";
                var body = "<h1>You Just <b><u>" + DateTime.Now.ToString() + "</u></b> Sign In To Our System.</h1>";
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub,
                    Body = body,
                    IsBodyHtml= true
                })
                {
                    smtp.Send(mess);
                }
            }
        }

        //GET: UrLogin/Register
        public ActionResult Register()
        {
            if (Session["uid"] == null)
            {
                Session["city"] = db.Tblcities.ToList();
                ViewBag.state = db.Tblstates.ToList();
                return View();
            }
            else
                return RedirectToAction("Index","UrEvents");
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

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index");
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
