using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TankStore.Models {
    public class TankContext : DbContext {
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<BuyOneModel> BuyOneModels { get; set; }
        public DbSet<OneBuy> OneBuys { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
