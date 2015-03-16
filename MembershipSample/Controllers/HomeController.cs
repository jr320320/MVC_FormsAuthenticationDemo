using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MembershipSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "abc123")
            {
                #region 書本範例
                //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                //    //你想要存放在 User.Identy.Name 的值，通常是使用者帳號
                //    account,
                //    DateTime.Now,
                //    DateTime.Now.AddMinutes(30),
                //    true,//將管理者登入的 Cookie 設定成 Session Cookie
                //    FormsAuthentication.FormsCookiePath);

                //string encTicket = FormsAuthentication.Encrypt(ticket);

                //var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                //cookie.HttpOnly = true;

                //Response.Cookies.Add(cookie);

                #endregion

                FormsAuthentication.SetAuthCookie(username, false);
                return RedirectToAction("secure");
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult Secure()
        {
            return View();
        }
    }
}