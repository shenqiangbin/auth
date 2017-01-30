using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FormAuth01.Models;

namespace FormAuth01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogOn()
        {
            //验证登录是否成功
            //如果成功，则
            var account = "admin";
            SetAuthCookie(account, "admin,teacher");
            return RedirectToAction("Index");
        }

        private void SetAuthCookie(string account, string userData)
        {
            //FormsAuthentication.SetAuthCookie(account, false);

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1, account, DateTime.Now,
                DateTime.Now.Add(FormsAuthentication.Timeout),
                false, userData);

            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            HttpContext.Response.Cookies.Add(cookie);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        [GodAuthorize(Roles = "student")]
        public ActionResult Info()
        {
            return View();
        }

        //登录界面
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult NonAuth()
        {
            return View();
        }
    }
}