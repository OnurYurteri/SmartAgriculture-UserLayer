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
            return View();
        }

        public JsonResult getLastMeasurement(string chipId)
        {
            return Json(measurementModel.getLastDeviceMeasurement(chipId), JsonRequestBehavior.AllowGet);
        }
    }
}