using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankStore.Models {
    public class BuyOneModel {
        public int Id { get; set; }
        public int tankId { get; set; }
        public string tankName { get; set; }
        public int countOfTanks { get; set; }
        public int summaryCost { get; set; }
        public int? OneBuyId { get; set; } 
        public OneBuy OneBuy { get; set; }
    }
}
