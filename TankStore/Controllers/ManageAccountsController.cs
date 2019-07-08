using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TankStore.Models;

namespace TankStore.Controllers {
    public class ManageAccountsController : Controller {
        TankContext db = new TankContext();
        int startCash = 1000;

        [HttpGet]
        public ActionResult Reg() {
            HttpContext.Response.Cookies["LoginUsed"].Value = "false";
            return View(db.Roles);
        }

        [HttpPost]
        public ActionResult Reg(string login, string password, string role) {
            Account account = db.Accounts.FirstOrDefault(a => a.Login == login);
            if (account == null) {
                Role accType = db.Roles.First(r => r.Name == role);
                db.Accounts.Add(new Account { Login = login, Password = password, Cash = startCash, RoleId = accType.Id });
                db.SaveChanges();
                FormsAuthentication.SetAuthCookie(login, true);
            }
            else {
                HttpContext.Response.Cookies["LoginUsed"].Value = "true";
                return View("Reg", db.Roles);
            }
            return View("SuccessfulReg");
        }

        [HttpGet]
        public ActionResult Login() {
            HttpContext.Response.Cookies["WrongData"].Value = "false";
            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string password) {
            Account account = db.Accounts.FirstOrDefault(a => a.Login == login && a.Password == password);
            if (account != null) {
                FormsAuthentication.SetAuthCookie(login, true);
            }
            else {
                HttpContext.Response.Cookies["WrongData"].Value = "true";
                return View("Login");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
