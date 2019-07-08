using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TankStore.Models;
using System.Web.Security;

namespace TankStore.Controllers {
    public class HomeController : Controller {
        TankContext db = new TankContext();

        public ActionResult Index() {
            HttpContext.Response.Cookies["isAdmin"].Value = "false";
            HttpContext.Response.Cookies["isClient"].Value = "false";
            if (User.Identity.IsAuthenticated) {
                string accLogin = User.Identity.Name;
                Account account = db.Accounts.Include(a => a.Role).FirstOrDefault(a => a.Login == accLogin);
                if (account != null) {
                    if (account.Role.Name == "admin") {
                        HttpContext.Response.Cookies["isAdmin"].Value = "true";
                    }
                    else {
                        HttpContext.Response.Cookies["isClient"].Value = "true";
                        string login = User.Identity.Name;
                        int clientCash = db.Accounts.FirstOrDefault(a => a.Login == login).Cash;
                        ViewBag.ClientCash = clientCash;
                    }
                }
            }

            if (Session["byCost"] == null) {
                return View(db.Tanks);
            }
            else {
                if (Session["byCost"].ToString() == "false") {
                    return View(db.Tanks);
                }
                else {
                    if (Session["byIncrease"].ToString() == "true") {
                        var tanks = db.Tanks.OrderBy(t => t.tankCost);
                        return View(tanks);
                    }
                    else {
                        var tanks = db.Tanks.OrderByDescending(t => t.tankCost);
                        return View(tanks);
                    }
                }
            }
        }

        protected override void Dispose(bool disposing) {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
