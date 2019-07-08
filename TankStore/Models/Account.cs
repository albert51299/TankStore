using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankStore.Models {
    public class Account {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Cash { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<OneBuy> OneBuys { get; set; }
        public Account() {
            OneBuys = new List<OneBuy>();
        }
    }

    public class Role {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
