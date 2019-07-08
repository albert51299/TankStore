using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TankStore.Models;

namespace TankStore.Controllers {
    public class ClientController : Controller {
        TankContext db = new TankContext();

        public ActionResult MyAccount() {
            string login = User.Identity.Name;
            Account account = db.Accounts.FirstOrDefault(a => a.Login == login);
            ViewBag.UserCash = account.Cash;

            int count = db.OneBuys.Where(o => o.AccountId == account.Id).Count();
            if (count == 0) {
                HttpContext.Response.Cookies["buysEmpty"].Value = "true";
            }
            else {
                HttpContext.Response.Cookies["buysEmpty"].Value = "false";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Buy(int[] ids, int[] counts) {
            OneBuy oneBuy = new OneBuy();
            for (int i = 0; i < counts.Length; i++) {
                if (counts[i] != 0) {
                    Tank tank = db.Tanks.Find(ids[i]);

                    oneBuy.oneBuyCount += counts[i];
                    oneBuy.oneBuyCost += tank.tankCost * counts[i];

                    oneBuy.BuyOneModels.Add(new BuyOneModel {
                        countOfTanks = counts[i], tankName = tank.tankName, tankId = ids[i],
                        summaryCost = tank.tankCost * counts[i]
                        
                    });
                }
            }
            return View(oneBuy);
        }

        [HttpPost]
        public ActionResult ConfirmBuying(int[] ids, int[] counts) {
            OneBuy oneBuy = new OneBuy();
            List<BuyOneModel> list = new List<BuyOneModel>();
            for (int i = 0; i < counts.Length; i++) {
                Tank tank = db.Tanks.Find(ids[i]);

                tank.tankCount -= counts[i];
                oneBuy.oneBuyCount += counts[i];
                oneBuy.oneBuyCost += tank.tankCost * counts[i];

                list.Add(new BuyOneModel {
                    countOfTanks = counts[i], tankName = tank.tankName, tankId = ids[i],
                    summaryCost = tank.tankCost * counts[i], OneBuy = oneBuy
                });
            }
            string login = User.Identity.Name;
            Account account = db.Accounts.FirstOrDefault(a => a.Login == login);
            account.Cash -= oneBuy.oneBuyCost;
            oneBuy.Account = account;

            db.OneBuys.Add(oneBuy);
            db.BuyOneModels.AddRange(list);
            db.SaveChanges();

            ViewBag.ClientCash = account.Cash;
            return View("SuccessfulBuy");
        }

        public ActionResult Sort() {
            return View();
        }

        [HttpPost]
        public ActionResult Sort(string sortBy, string orderBy) {
            if (sortBy == "cost") {
                Session["byCost"] = "true";
                if (orderBy == "byIncrease") {
                    Session["byIncrease"] = "true";
                }
                else {
                    Session["byIncrease"] = "false";
                }
            }
            else {
                Session["byCost"] = "false";
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ShowClientBuys() {
            string login = User.Identity.Name;
            int clientId = db.Accounts.FirstOrDefault(a => a.Login == login).Id;
            var clientBuys = db.OneBuys.Include(o => o.BuyOneModels).Where(o => o.AccountId == clientId);
            return View(clientBuys);
        }

        [HttpGet]
        public ActionResult AddGold(int gold) {
            string login = User.Identity.Name;
            Account account = db.Accounts.FirstOrDefault(a => a.Login == login);
            account.Cash += gold;
            db.SaveChanges();
            ViewBag.UserCash = account.Cash;
            return View("MyAccount");
        }
    }
}
