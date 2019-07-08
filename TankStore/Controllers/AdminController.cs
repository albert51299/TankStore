using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TankStore.Models;

namespace TankStore.Controllers {
    public class AdminController : Controller {
        TankContext db = new TankContext();

        public ActionResult ControlPanel() {
            return View(db.Tanks);
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            Tank tank = db.Tanks.FirstOrDefault(a => a.TankId == id);
            return View(tank);
        }

        [HttpPost]
        public ActionResult Edit(Tank tank) {
            db.Entry(tank).State = EntityState.Modified;
            db.SaveChanges();  
            return View("ControlPanel", db.Tanks);
        }

        public ActionResult Add() {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Tank tank) {
            db.Tanks.Add(tank);
            db.SaveChanges();
            return View("ControlPanel", db.Tanks);
        }
    }
}
