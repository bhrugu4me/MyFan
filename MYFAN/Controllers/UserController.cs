using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MYFAN.BusinessLogic;

namespace MYFAN.Presentation.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ActionName("sign-in")]
        public ActionResult Login()
        {
            object vmLogin = new LoginViewModel();
            return View(vmLogin);
        }

        [HttpPost]
        [ActionName("sign-in")]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            try
            {
                if (Session != null)
                {
                    Session.Clear();
                    Session.Abandon();
                }
                FormsAuthentication.SignOut();
                System.Web.HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(String.Empty), null);
                ModelState.Clear();
                if (ModelState.IsValid)
                {
                    bool sucsess = model.validate(model);
                    if (sucsess)
                    {
                        Session["Credencial"] = model;
                        SetUserAuthCookie();
                        return RedirectToAction("index", "admin");
                    }
                    else
                    {
                        ModelState.AddModelError("EmailAddress", "Invalid Email Address or Password.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please enter a Email Address and Password.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }

        private void SetUserAuthCookie()
        {
            Crypto crypto = new Crypto();
            FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, Session.SessionID, DateTime.Now, DateTime.Now.AddMinutes(FormsAuthentication.Timeout.Minutes), false, crypto.EncryptString(JsonConvert.SerializeObject(Session["Credencial"])));
            string CookieString = FormsAuthentication.Encrypt(Ticket);
            HttpCookie Cookie = new HttpCookie(FormsAuthentication.FormsCookieName, CookieString);
            Cookie.Expires = Ticket.Expiration;
            Cookie.Path = FormsAuthentication.FormsCookiePath;
            Cookie.HttpOnly = true;
            System.Web.HttpContext.Current.Response.Cookies.Add(Cookie);
        }
    }
}