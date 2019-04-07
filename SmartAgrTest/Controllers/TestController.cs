using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartAgrTest.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            if (Session["USER"] != null && Request.Cookies["AUTHID"] != null && Request.Cookies["AUTHID"].Value == Session["AUTHID"].ToString())
            {
                ViewBag.Title = "Test";
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
    }
}