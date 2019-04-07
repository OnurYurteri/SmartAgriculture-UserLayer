using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartAgrTest.Models;
using SmartAgrTest.Entitites;
using System.Security.Cryptography;

namespace SmartAgrTest.Controllers
{
    public class LoginController : Controller
    {
        private AccountModel accountModel = new AccountModel();

        // GET: Login
        public ActionResult Index()
        {
            if (Session["USER"]!=null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.Title = "Giriş Yap";
            return View();
        }

        [HttpPost]
        public ActionResult Auth(string username, string password)
        {
            var account = accountModel.findWithUsername(username);
            if (account == null)
            {
                return Json(new { success = false, err = "Kullanıcı bulunamadı." }, JsonRequestBehavior.AllowGet);
            }
            else if (account.Password != getMd5Hash(password))
            {
                
                return Json(new { success = false, err = "Giriş bilgilerinizi kontrol ediniz." }, JsonRequestBehavior.AllowGet);
            }
            else if (!account.IsAdmin)
            {
                return Json(new { success = false, err = "Bu sayfa için yetkili değilsiniz." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session["USER"] = account.Username;
                string authId = Guid.NewGuid().ToString();
                Session["AUTHID"] = authId;
                //if (Request.Cookies["AUTHID"] != null)
                //{
                //    var authCookie = new HttpCookie("AUTHID");
                //    authCookie.Expires = DateTime.Now.AddDays(-1d);
                //    Response.Cookies.Add(authCookie);
                //}
                var authCookie = new HttpCookie("AUTHID");
                authCookie.Value = authId;
                Response.Cookies.Add(authCookie);
                return Json(new { success = "true", url = "/Dashboard" }, JsonRequestBehavior.AllowGet);
            }
        }

        private string getMd5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(System.Text.Encoding.Default.GetBytes(input));
            System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}