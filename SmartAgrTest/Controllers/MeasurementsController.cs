using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartAgrTest.Models;
using SmartAgrTest.Entitites;

namespace SmartAgrTest.Controllers
{
    public class MeasurementsController : Controller
    {
        MeasurementModel measurementModel = new MeasurementModel();
        // GET: Measurement
        public ActionResult Index()
        {
            if (Session["USER"] != null && Request.Cookies["AUTHID"] != null && Request.Cookies["AUTHID"].Value == Session["AUTHID"].ToString())
            {
                ViewBag.Title = "Geçmiş Ölçümler";
                ViewBag.Description = "<i class=\"fas fa-plus - circle\"></i> 'ya tıklayarak Ölçüm Görüntüleme Ekranı Oluştabilirsiniz.";
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

        public JsonResult getLastMeasurement(string chipId)
        {
            return Json(measurementModel.getLastDeviceMeasurement(chipId), JsonRequestBehavior.AllowGet);
        }
    }
}