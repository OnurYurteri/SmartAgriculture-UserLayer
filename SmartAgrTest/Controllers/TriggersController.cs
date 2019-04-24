using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartAgrTest.Models;
using SmartAgrTest.Entitites;

namespace SmartAgrTest.Controllers
{
    public class TriggersController : Controller
    {
        private TriggerModel triggerModel = new TriggerModel();

        // GET: Triggers
        public ActionResult Index()
        {
            if (Session["USER"] != null && Request.Cookies["AUTHID"] != null && Request.Cookies["AUTHID"].Value == Session["AUTHID"].ToString())
            {
                ViewBag.Title = "Tetik Eylemler";
                ViewBag.Username = Session["USER"];
                return View();
            }
            //sahtecilik olmasına karşın
            if (Session["USER"] != null)
            {
                Session.Remove("USER");
            }
            if (Request.Cookies["AUTHID"] != null)
            {
                var authCookie = new HttpCookie("AUTHID");
                authCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(authCookie);
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public JsonResult GetTriggers()
        {
            var triggers = triggerModel.findAll();
            return Json(triggers, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateTrigger(TriggerEntity triggerToUpdate)
        {
            
            if (triggerModel.update(triggerToUpdate))
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult InsertTrigger(TriggerEntity triggerToInsert)
        {
            if (triggerModel.insert(triggerToInsert))
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}