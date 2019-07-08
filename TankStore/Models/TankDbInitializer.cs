using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TankStore.Models {
    public class TankDbInitializer : DropCreateDatabaseAlways<TankContext>{
        protected override void Seed(TankContext db) {
            db.Tanks.Add(new Tank { tankName = "T-34", tankCountry = "USSR", tankCost = 100, tankCount = 5 });
            db.Tanks.Add(new Tank { tankName = "KV-1", tankCountry = "USSR", tankCost = 200, tankCount = 2 });
            db.Tanks.Add(new Tank { tankName = "KV-2", tankCountry = "USSR", tankCost = 500, tankCount = 1 });
            db.Tanks.Add(new Tank { tankName = "T-95", tankCountry = "USA", tankCost = 10, tankCount = 50 });
            db.Tanks.Add(new Tank { tankName = "T110E5", tankCountry = "USA", tankCost = 1000, tankCount = 4 });

            db.Roles.Add(new Role { Id = 1, Name = "admin" });
            db.Roles.Add(new Role { Id = 2, Name = "client" });

            base.Seed(db);
        }
    }
}
