using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            FormsAuthentication.SetAuthCookie(account, false);            
            return RedirectToAction("Index");
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}