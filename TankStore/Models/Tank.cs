using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankStore.Models {
    public class Tank {
        public int TankId { get; set; }
        public string tankName { get; set; }
        public string tankCountry { get; set; }
        public int tankCost { get; set; }
        public int tankCount { get; set; }
    }
}
