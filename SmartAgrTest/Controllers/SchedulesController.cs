using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartAgrTest.Models;
using SmartAgrTest.Entitites;
using System.Collections;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartAgrTest.Controllers
{
    public class SchedulesController : Controller
    {
        private ScheduleModel scheduleModel = new ScheduleModel();
        // GET: Schedules
        public ActionResult Index()
        {
            if (Session["USER"] != null && Request.Cookies["AUTHID"] != null && Request.Cookies["AUTHID"].Value == Session["AUTHID"].ToString())
            {
                ViewBag.Title = "Programlar";
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
        public JsonResult GetSchedules()
        {
            var devices = scheduleModel.findAll();
            return Json(devices, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ScheduleCount()
        {
            return Json(scheduleModel.scheduleCount(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateSchedule(ScheduleEntity scheduleToUpdate)
        {
            var sch = scheduleModel.findWithId(scheduleToUpdate.Id);
            if (scheduleModel.update(scheduleToUpdate))
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult InsertSchedule(ScheduleEntity scheduleToInsert)
        {
            if (scheduleModel.insert(scheduleToInsert))
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DeleteScheduleWithId(string _id)
        {
            if (scheduleModel.removeScheduleWithId(_id))
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult UpdateStateWithScheduleId(string _id, bool state)
        {
            if (scheduleModel.updateStateWithScheduleId(_id, state))
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