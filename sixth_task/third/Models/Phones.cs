using System;
using System.Collections.Generic;

namespace third
{
    public partial class Phones
    {
        public Phones()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
