using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartAgrTest.Models;
using SmartAgrTest.Entitites;

namespace SmartAgrTest.Controllers
{
    public class DevicesController : Controller
    {
        private DeviceModel deviceModel = new DeviceModel();
        // GET: Devices
        public ActionResult Index()
        {
            if (Session["USER"] != null && Request.Cookies["AUTHID"] != null && Request.Cookies["AUTHID"].Value == Session["AUTHID"].ToString())
            {
                ViewBag.Title = "Cihazlar";
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
        public JsonResult GetDevices()
        {
            var devices = deviceModel.findAll();
            return Json(devices, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetRelays()
        {
            var devices = deviceModel.findRelays();
            return Json(devices, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateDevice(DeviceEntity dev)
        {
            if (deviceModel.update(dev))
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