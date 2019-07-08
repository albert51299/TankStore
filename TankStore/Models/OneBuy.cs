using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankStore.Models {
    public class OneBuy {
        public int Id { get; set; }
        public int oneBuyCount { get; set; }
        public int oneBuyCost { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public ICollection<BuyOneModel> BuyOneModels { get; set; }
        public OneBuy() {
            BuyOneModels = new List<BuyOneModel>();
        }

    }
}
