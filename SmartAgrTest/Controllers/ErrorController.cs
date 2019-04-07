using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartAgrTest.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string title, string errCode, string textToDisplay)
        {
            ViewBag.Title = title;
            ViewBag.ErrorCode = errCode;
            ViewBag.Text = textToDisplay;
            return View();
        }

        public ActionResult NotFound()
        {
            return View("Sayfa Bulunamadı", "404", "Matrix'de bir dalgalanma oldu..");
        }
    }
}