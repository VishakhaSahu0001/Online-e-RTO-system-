using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RTAInformationSystem.Models;
using System.Data.Entity;

namespace RTAInformationSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Services()
        {

            return View();
        }
        public ActionResult Challen()
        {
            return View();
        }
        public ActionResult Apply()
        {
            return View();
        }
        public ActionResult Registrattion()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(RegisterTbl registerTbl)
        {
            using(RTADataEntities entities=new RTADataEntities())
            {
                if(ModelState.IsValid)
                {
                    entities.RegisterTbls.Add(registerTbl);
                    entities.SaveChanges();
                    ViewBag.success = "Registration Successfull";
                    ModelState.Clear();
                }
            }
            return View(registerTbl);
        }
        [HttpPost]
        public ActionResult Apply(ApplyTbl applyTbl)
        {
            using (RTADataEntities entities = new RTADataEntities())
            {
                if (ModelState.IsValid)
                {
                    entities.ApplyTbls.Add(applyTbl);
                    entities.SaveChanges();
                    ViewBag.success = "Apply Successfull";
                    ModelState.Clear();
                }
            }
            return View(applyTbl);
        }
        [HttpPost]
        public ActionResult Challen(ChallenTbl challenTbl)
        {
            using (RTADataEntities entities = new RTADataEntities())
            {
                if (ModelState.IsValid)
                {
                    entities.ChallenTbls.Add(challenTbl);
                    entities.SaveChanges();
                    ViewBag.success = "Challen add Successfull";
                    ModelState.Clear();
                }
            }
            return View(challenTbl);
        }
        [HttpPost]
        public ActionResult Login(RegisterTbl tblRegister)
        {
            if (ModelState.IsValid)
            {
                using (RTADataEntities db = new RTADataEntities())
                {
                    var obj = db.RegisterTbls.Where(a => a.email.Equals(tblRegister.email) && a.pass.Equals(tblRegister.pass)).FirstOrDefault();
                    if (obj != null)
                    {
                        //Session["UserID"] = obj.UserId.ToString();
                        //Session["UserName"] = obj.email.ToString();
                        return RedirectToAction("Home/Apply");
                    }
                }
            }
            return View(tblRegister);
        }
    }
}